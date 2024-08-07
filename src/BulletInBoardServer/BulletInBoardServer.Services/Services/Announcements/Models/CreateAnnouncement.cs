﻿namespace BulletInBoardServer.Services.Services.Announcements.Models;

/// <summary>
/// Объект со сведениями для создания нового объявления
/// </summary>
/// <param name="content">Контент объявления</param>
/// <param name="userIds">Идентификаторы пользователей, составляющих аудиторию объявления</param>
/// <param name="attachmentIds">Идентификаторы вложений</param>
/// <param name="delayedPublishingAt">Момент отложенной публикации. Null, если отложенная публикация не задана</param>
/// <param name="delayedHidingAt">Момент отложенного сокрытия. Null, если отложенное сокрытие не задано</param>
public class CreateAnnouncement(
    string content,
    IEnumerable<Guid> userIds,
    IEnumerable<Guid> attachmentIds,
    DateTime? delayedPublishingAt,
    DateTime? delayedHidingAt)
{
    /// <summary>
    /// Контент объявления
    /// </summary>
    public string Content { get; } = content;

    /// <summary>
    /// Идентификаторы пользователей, составляющих аудиторию объявления
    /// </summary>
    public IEnumerable<Guid> UserIds { get; } = userIds;

    /// <summary>
    /// Идентификаторы вложений
    /// </summary>
    public IEnumerable<Guid> AttachmentIds { get; } = attachmentIds;

    /// <summary>
    /// Момент отложенной публикации
    /// </summary>
    /// <remarks>
    /// Null, если отложенная публикация не задана
    /// </remarks>
    public DateTime? DelayedPublishingAt { get; } = delayedPublishingAt;

    /// <summary>
    /// Момент отложенного сокрытия
    /// </summary>
    /// <remarks>
    /// Null, если отложенное сокрытие не задано
    /// </remarks>
    public DateTime? DelayedHidingAt { get; } = delayedHidingAt;
}