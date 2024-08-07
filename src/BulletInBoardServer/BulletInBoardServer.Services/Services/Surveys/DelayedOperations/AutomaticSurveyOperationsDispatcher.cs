﻿using System.ComponentModel;
using BulletInBoardServer.Domain;

namespace BulletInBoardServer.Services.Services.Surveys.DelayedOperations;

public class AutomaticSurveyOperationsDispatcher : IAutomaticSurveyOperationsDispatcher
{
    private static Dictionary<Guid, AutomaticSurveyClosingService> _automaticClosingServices = [];

    private readonly AutoClosingSurveyService _closingService;



    public AutomaticSurveyOperationsDispatcher(AutoClosingSurveyService closingService)
    {
        _closingService = closingService;
    }



    public static void Init(ApplicationDbContext dbContext, AutoClosingSurveyService closingService)
    {
        _automaticClosingServices = dbContext.Surveys
            .Where(a => a.ExpectsAutoClosing)
            .ToDictionary(
                a => a.Id,
                a => CreateAndRunAutoClosingService(a.Id, a.AutoClosingAt!.Value, closingService)); 
        // AutoClosingAt не null, если ExpectsAutoClosing true
    }

    public void ConfigureAutoClosing(Guid surveyId, DateTime closeAt)
    {
        var service = CreateAndRunAutoClosingService(surveyId, closeAt, _closingService);
        _automaticClosingServices[surveyId] = service;
    }

    public void DisableAutoClosing(Guid surveyId) =>
        _automaticClosingServices[surveyId].CancelAsync();



    private static AutomaticSurveyClosingService CreateAndRunAutoClosingService(Guid surveyId, DateTime closeAt,
        AutoClosingSurveyService closingService)
    {
        var service = new AutomaticSurveyClosingService(surveyId, closeAt, closingService);
        service.WorkerSupportsCancellation = true;
        service.RunWorkerCompleted += RemoveDelayedClosingServiceFromCollection;

        service.RunWorkerAsync();

        return service;
    }
    
    private static void RemoveDelayedClosingServiceFromCollection(object? sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Result is null)
            throw new ArgumentException(
                "Результат выполнения сервиса автоматического сокрытия опроса не может быть null");

        var announcementId = (Guid)e.Result;
        _automaticClosingServices.Remove(announcementId);
    }
}