﻿using BulletInBoardServer.Domain.Models.Announcements;

namespace BulletInBoardServer.Services.Services.Announcements.Models;

public static class AnnouncementSummaryExtensions
{
    public static AnnouncementSummary GetSummary(this Announcement announcement, int viewsCount) =>
        new(
            id: announcement.Id,
            author: announcement.Author,
            content: announcement.Content,
            viewsCount: viewsCount,
            audienceSize: announcement.AudienceSize,
            firstlyPublishedAt: announcement.FirstlyPublishedAt,
            publishedAt: announcement.PublishedAt,
            hiddenAt: announcement.HiddenAt, 
            delayedPublishingAt: announcement.DelayedPublishingAt, 
            delayedHidingAt: announcement.DelayedHidingAt, 
            attachments: announcement.Attachments);
}