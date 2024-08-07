﻿using BulletInBoardServer.Services.Services.Common.Models;

namespace BulletInBoardServer.Services.Services.Announcements.Models;

/// <summary>
/// Класс с данными для редактирования объявления, принимаемый от клиента
/// </summary>
public class EditAnnouncement
{
    /// <summary>
    /// Id редактируемого объявления
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Новый текст объявления
    /// </summary>
    /// <remarks>
    /// Null, если текст не был изменен
    /// </remarks>
    public string? Content { get; init; }

    /// <summary>
    /// Новый список идентификаторов пользователей-аудитории объявления
    /// </summary>
    /// <remarks>
    /// Null, если аудитория не была изменена
    /// </remarks>
    public UpdateIdentifierList? AudienceIds { get; init; }

    /// <summary>
    /// Новый список идентификаторов вложений объявления
    /// </summary>
    /// <remarks>
    /// Null, если список вложений не был изменен
    /// </remarks>
    public UpdateIdentifierList? AttachmentIds { get; init; }

    /// <summary>
    /// Флаг, отображающий изменение момента отложенной публикации <see cref="DelayedPublishingAt"/>
    /// </summary>
    public bool DelayedPublishingAtChanged { get; init; }

    /// <summary>
    /// Новый момент отложенной публикации объявления
    /// </summary>
    /// <remarks>
    /// Если время публикации было изменено, устанавливается флаг <see cref="DelayedPublishingAtChanged"/> 
    /// </remarks>
    public DateTime? DelayedPublishingAt { get; init; }

    /// <summary>
    /// Флаг, отображающий изменение момента автоматического сокрытия <see cref="DelayedHidingAt"/>
    /// </summary>
    public bool DelayedHidingAtChanged { get; init; }

    /// <summary>
    /// Новый момент автоматического сокрытия публикации объявления
    /// </summary>
    /// <remarks>
    /// Если время сокрытия было изменено, устанавливается флаг <see cref="DelayedHidingAtChanged"/> 
    /// </remarks>
    public DateTime? DelayedHidingAt { get; init; }
}