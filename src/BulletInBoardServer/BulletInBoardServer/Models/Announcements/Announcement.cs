﻿using BulletInBoardServer.Models.AnnouncementCategories;
using BulletInBoardServer.Models.Attachments;
using BulletInBoardServer.Models.Attachments.Surveys;
using BulletInBoardServer.Models.Users;

namespace BulletInBoardServer.Models.Announcements;

public class Announcement
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Текстовое содержимое объявления
    /// </summary>
    public string Content
    {
        get => _content;
        set => SetContent(value);
    }

    /// <summary>
    /// Идентификатор автора объявления
    /// </summary>
    public Guid AuthorId { get; init; }

    /// <summary>
    /// Автор объявления
    /// </summary>
    /// <remarks>
    /// Поле должно устанавливаться только при помощи Entity Framework или конструктора.
    /// Перед использование обязательно должно быть установлено
    /// </remarks>
    public User Author { get; init; } = null!;

    /// <summary>
    /// Категории объявления
    /// </summary>
    /// <remarks>
    /// Поле должно устанавливаться только при помощи Entity Framework или конструктора.
    /// Перед использование обязательно должно быть установлено
    /// </remarks>
    public AnnouncementCategoryList Categories { get; init; } = null!;

    /// <summary>
    /// Аудитория объявления
    /// </summary>
    /// <remarks>
    /// Поле должно устанавливаться только при помощи Entity Framework или конструктора.
    /// Перед использование обязательно должно быть установлено
    /// </remarks>
    public AnnouncementAudience Audience { get; init; } = null!;
    
    /// <summary>
    /// Размер аудитории объявления
    /// </summary>
    public int AudienceSize { get; init; }

    /// <summary>
    /// Момент публикации уже опубликованного объявления. Null, если объявления не опубликовано
    /// </summary>
    public DateTime? PublishedAt
    {
        get => _publishedAt;
        set => SetPublishedMoment(value);
    }

    public bool IsPublished => PublishedAt is not null;

    /// <summary>
    /// Момент автоматической публикации объявления. Null, если автоматическая публикация не задана
    /// </summary>
    public DateTime? AutoPublishingAt
    {
        get => _autoPublishingAt;
        set => SetAutoPublishingMoment(value);
    }

    public bool ExpectsAutoPublishing => AutoPublishingAt is not null;

    /// <summary>
    /// Момент сокрытия уже скрытого объявления. Null, если объявления не скрыто
    /// </summary>
    public DateTime? HiddenAt
    {
        get => _hiddenAt;
        set => SetHiddenAtMoment(value);
    }

    public bool IsHidden => HiddenAt is not null;

    /// <summary>
    /// Момент автоматического сокрытия объявления. Null, если автоматическое сокрытие не задано
    /// </summary>
    public DateTime? AutoHidingAt
    {
        get => _autoHidingAt;
        set => SetAutoHidingMoment(value);
    }

    public bool ExpectsAutoHiding => AutoHidingAt is not null;

    /// <summary>
    /// Прикрепление к объявлению
    /// </summary>
    /// <remarks>
    /// Поле должно устанавливаться только при помощи Entity Framework или конструктора.
    /// Перед использование обязательно должно быть установлено
    /// </remarks>
    public AttachmentList Attachments { get; init; } = [];



    private string _content = null!;
    private DateTime? _autoPublishingAt;
    private DateTime? _autoHidingAt;
    private DateTime? _publishedAt;
    private DateTime? _hiddenAt;

    private bool ContainsSurvey => Attachments.Any(a => a is Survey);



    public Announcement(Guid id, string content, User author, AnnouncementCategories.AnnouncementCategoryList categories,
        AnnouncementAudience audience, DateTime? publishedAt, DateTime? hiddenAt, DateTime? autoPublishingAt,
        DateTime? autoHidingAt, AttachmentList attachments)
    {
        CategoriesValidOrThrow(categories);
        AudienceValidOrThrow(audience);  
        
        Id = id;
        Content = content;
        AuthorId = author.Id;
        Author = author;
        Categories = categories;
        Audience = audience;
        AudienceSize = audience.Count;
        PublishedAt = publishedAt;
        HiddenAt = hiddenAt;
        AutoPublishingAt = autoPublishingAt;
        AutoHidingAt = autoHidingAt;
        
        if (attachments.Count > 0)
            Attach(attachments);
    }
    
    public Announcement(Guid id, string content, Guid authorId,
        DateTime? publishedAt, DateTime? hiddenAt, DateTime? autoPublishingAt,
        DateTime? autoHidingAt)
    {
        Id = id;
        Content = content;
        AuthorId = authorId;
        PublishedAt = publishedAt;
        HiddenAt = hiddenAt;
        AutoPublishingAt = autoPublishingAt;
        AutoHidingAt = autoHidingAt;
    }



    public void Attach(AttachmentBase attachment) => 
        AddAttachmentOrThrow(attachment);

    public void Attach(AttachmentList attachments)
    {
        ArgumentNullException.ThrowIfNull(attachments);

        foreach (var attachment in attachments) 
            AddAttachmentOrThrow(attachment);
    }

    public void Unattach(AttachmentBase attachment) => 
        Attachments.Remove(attachment);



    private void SetContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Контент не может быть null или состоять только из пробельных символов");
        
        _content = content;
    }
    
    private static void CategoriesValidOrThrow(AnnouncementCategories.AnnouncementCategoryList categories) => 
        ArgumentNullException.ThrowIfNull(categories);

    private static void AudienceValidOrThrow(AnnouncementAudience audience)
    {
        ArgumentNullException.ThrowIfNull(audience);
        if (!audience.Any())
            throw new ArgumentException("Аудитория объявления не может быть пустой");      
    }

    private void SetPublishedMoment(DateTime? publishedAt)
    {
        if (PublishedAt is not null)
            throw new InvalidOperationException("Время публикации объявления не может быть изменено");

        if (DateTime.Now < publishedAt)
            throw new InvalidOperationException(
                "Момент публикации уже опубликованного объявления не может наступить в будущем");

        if (IsHidden && HiddenAt <= publishedAt)
            throw new InvalidOperationException(
                "Момент публикации уже опубликованного объявления не может наступить позже момента его сокрытия");

        _publishedAt = publishedAt;
    }

    private void SetHiddenAtMoment(DateTime? hiddenAt)
    {
        if (DateTime.Now < hiddenAt)
            throw new InvalidOperationException(
                "Момент сокрытия уже скрытого объявления не может наступить в будущем");

        if (IsPublished && hiddenAt <= PublishedAt ||
            ExpectsAutoPublishing && hiddenAt < AutoPublishingAt)
            throw new InvalidOperationException("Объявление не могло быть скрыто до момента публикации");

        _hiddenAt = hiddenAt;
    }

    private void SetAutoPublishingMoment(DateTime? publishAt)
    {
        if (publishAt is null)
        {
            _autoPublishingAt = null;
            return;
        }

        if (IsPublished)
            throw new InvalidOperationException(
                "Нельзя задать момент автоматической публикации уже опубликованному объявлению");

        if (publishAt < DateTime.Now)
            throw new InvalidOperationException(
                "Автоматическая публикация объявления не может произойти в прошлом");

        _autoPublishingAt = publishAt;
    }

    private void SetAutoHidingMoment(DateTime? hideAt)
    {
        if (hideAt is null)
        {
            _autoHidingAt = null;
            return;
        }

        if (IsHidden)
            throw new InvalidOperationException(
                "Нельзя задать срок автоматического сокрытия уже скрытому объявлению");

        if (hideAt < DateTime.Now)
            throw new InvalidOperationException(
                "Автоматическое сокрытие объявления не может произойти в прошлом");

        _autoHidingAt = hideAt;
    }
    
    private void AddAttachmentOrThrow(AttachmentBase attachment)
    {
        ArgumentNullException.ThrowIfNull(attachment);

        var isSurvey = attachment is Survey; 
        if (isSurvey && ContainsSurvey)
            throw new InvalidOperationException("Объявление уже содержит опрос");
        
        Attachments.Add(attachment);
    }
}