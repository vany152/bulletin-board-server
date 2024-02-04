﻿using BulletInBoardServer.DataAccess;
using BulletInBoardServer.Services.Announcements.DelayedOperations;
using BulletInBoardServer.Services.Announcements.Infrastructure;

namespace BulletInBoardServer.Services.Announcements.ServiceCore;

public class HiddenAnnouncementService(
    ApplicationDbContext dbContext,
    IDelayedAnnouncementOperationsDispatcher dispatcher)
    : CoreAnnouncementServiceBase(dbContext, dispatcher)
{
    /// <summary>
    /// Метод возвращает список скрытых объявлений для указанного пользователя
    /// </summary>
    /// <param name="requesterId">Id запросившего операцию пользователя</param>
    /// <returns>Список с краткой информацией об объявлениях</returns>
    public IEnumerable<AnnouncementSummary> GetListForUser(Guid requesterId) =>
        DbContext.Announcements
            .Where(a => a.AuthorId == requesterId && a.IsHidden)
            .Select(a => new
            {
                Announcement = a,
                ViewsCount = DbContext.AnnouncementAudience.Count(au => au.AnnouncementId == a.Id && au.Viewed)
            })
            .Select(res => res.Announcement.GetSummary(res.ViewsCount));

    /// <summary>
    /// Метод восстанавливает скрытое объявление
    /// </summary>
    /// <param name="requesterId">Id запросившего операцию пользователя</param>
    /// <param name="announcementId">Id восстанавливаемого объявления</param>
    /// <param name="restoredAt">Время восстановления объявления</param>
    public void Restore(Guid requesterId, Guid announcementId, DateTime restoredAt)
    {
        var announcement = GetAnnouncementSummary(announcementId);
        if (announcement.AuthorId != requesterId)
            throw new InvalidOperationException("Восстановить скрытое объявление может только его автор");

        if (announcement.ExpectsDelayedPublishing)
            Dispatcher.DisableDelayedPublishing(announcementId);

        announcement.Restore(restoredAt);
        DbContext.SaveChanges();
    }
}