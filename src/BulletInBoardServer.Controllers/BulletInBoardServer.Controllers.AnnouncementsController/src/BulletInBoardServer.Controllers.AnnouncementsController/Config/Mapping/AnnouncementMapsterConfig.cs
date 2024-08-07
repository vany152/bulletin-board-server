﻿using System;
using System.Collections.Generic;
using System.Linq;
using BulletInBoardServer.Controllers.AnnouncementsController.Models;
using BulletInBoardServer.Domain.Models.Announcements;
using BulletInBoardServer.Domain.Models.Attachments.Surveys;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.Answers;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.Questions;
using BulletInBoardServer.Domain.Models.UserGroups;
using BulletInBoardServer.Domain.Models.UserGroups.Exceptions;
using BulletInBoardServer.Domain.Models.Users;
using BulletInBoardServer.Services.Services.Announcements.Models;
using Mapster;

namespace BulletInBoardServer.Controllers.AnnouncementsController.Config.Mapping;

// ReSharper disable once UnusedType.Global - will be used on startup while IRegisters scanning
/// <inheritdoc />
public class AnnouncementMapsterConfig : IRegister
{
    /// <inheritdoc />
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAnnouncementDto, CreateAnnouncement>()
            .ConstructUsing(src => new CreateAnnouncement(
                src.Content, 
                src.UserIds, 
                src.AttachmentIds, 
                src.DelayedPublishingAt != null ? DateTime.SpecifyKind(src.DelayedPublishingAt.Value, DateTimeKind.Local) : null,
                src.DelayedHidingAt != null ? DateTime.SpecifyKind(src.DelayedHidingAt.Value, DateTimeKind.Local) : null));

        config.NewConfig<Announcement, AnnouncementDetailsDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Content, s => s.Content)
            // .Map(d => d.AuthorName, s => $"{s.Author.FirstName} {s.Author.SecondName} {s.Author.Patronymic}")
            .Map(d => d.AuthorName, s => s.Author.FullName)
            .Map(d => d.ViewsCount, s => s.ViewsCount)
            .Map(d => d.AudienceSize, s => s.AudienceSize)
            .Map(d => d.Surveys, s => s.Attachments.OfType<Survey>())
            .Map(d => d.HiddenAt, s => s.HiddenAt)
            .Map(d => d.PublishedAt, s => s.PublishedAt)
            .Map(d => d.DelayedPublishingAt, s => s.DelayedPublishingAt)
            .Map(d => d.DelayedHidingAt, s => s.DelayedHidingAt)
            // .Map(d => d.Audience, s => s.AudienceThreeNode); // todo remove
            .Map(d => d.Audience, s => s.Audience);

        // config.NewConfig<User, string>()
        //     .MapWith(src => $"{src.FirstName} {src.SecondName} {src.Patronymic}");

        // config.NewConfig<IAudienceNode, AnnouncementAudienceDto>() // remove
        //     .ConstructUsing(src => new AnnouncementAudienceDto 
        //     { 
        //         RootNode = src.Adapt<AnnouncementAudienceDtoRootNode>()
        //     });

        // config.NewConfig<__AudienceNode, AnnouncementAudienceDtoRootNode>()
        //     // src is user
        //     .Map(dst => dst.Id, src => src.User.Id, src => src.User != null)
        //     .Map(dst => dst.FirstName, src => src.User.FirstName, src => src.User != null)
        //     .Map(dst => dst.SecondName, src => src.User.SecondName, src => src.User != null)
        //     .Map(dst => dst.Patronymic, src => src.User.Patronymic, src => src.User != null)
        //     // src is usergroup
        //     .Map(dst => dst.Id, src => src.UserGroup.Id, src => src.UserGroup != null)
        //     .Map(dst => dst.Nodes, src => src.UserGroup.ChildrenGroups, src => src.UserGroup != null); // todo мб добавить Adapt на ChildrenGroups

        config.NewConfig<UpdateAnnouncementDto, EditAnnouncement>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Content, s => s.Content)
            .Map(d => d.AudienceIds, s => s.AudienceIds)
            .Map(d => d.AttachmentIds, s => s.AttachmentIds)
            .Map(d => d.DelayedPublishingAtChanged, s => s.DelayedPublishingAtChanged)
            .Map(d => d.DelayedPublishingAt, s => s.DelayedPublishingAt, s => s.DelayedPublishingAtChanged)
            .Map(d => d.DelayedHidingAtChanged, s => s.DelayedHidingAtChanged)
            .Map(d => d.DelayedHidingAt, s => s.DelayedHidingAt, s => s.DelayedHidingAtChanged);

        config.NewConfig<AnnouncementSummary, AnnouncementSummaryDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Author, s => s.Author)
            .Map(d => d.Content, s => s.Content)
            .Map(d => d.Content, s => s.Content)
            .Map(d => d.ViewsCount, s => s.ViewsCount)
            .Map(d => d.AudienceSize, s => s.AudienceSize)
            .Map(d => d.PublishedAt, s => s.PublishedAt)
            .Map(d => d.DelayedPublishingAt, s => s.DelayedPublishingAt)
            .Map(d => d.DelayedHidingAt, s => s.DelayedHidingAt)
            .Map(d => d.Surveys, a => a.Attachments.OfType<Survey>());

        config.NewConfig<Survey, SurveyDetailsDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.IsOpen, s => s.IsOpen)
            .Map(d => d.IsVotedByRequester, s => s.IsVotedByRequester)
            .Map(d => d.ResultsOpenBeforeClosing, s => s.ResultsOpenBeforeClosing)
            .Map(d => d.IsAnonymous, s => s.IsAnonymous)
            .Map(d => d.Voters, s => s.Voters)
            .Map(d => d.AutoClosingAt, s => s.AutoClosingAt)
            .Map(d => d.VoteFinishedAt, s => s.VoteFinishedAt)
            .Map(d => d.Questions, s => s.Questions.OrderBy(q => q.Serial));

        config.NewConfig<Question, QuestionDetailsDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Content, s => s.Content)
            .Map(d => d.IsMultipleChoiceAllowed, s => s.IsMultipleChoiceAllowed)
            .Map(d => d.Answers, s => s.Answers);

        config.NewConfig<Answer, QuestionAnswerDetailsDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Content, s => s.Content)
            .Map(d => d.Voters, s => s.Participation.Select(p => p.User))
            .Map(d => d.VotersAmount, s => s.VotersCount);

        config.NewConfig<UserGroupList, UsergroupHierarchyDto>()
            .Map(d => d.Roots, s => s)
            .Map(d => d.Usergroups, s => s);

        config.NewConfig<UserGroupList, List<UserGroupSummaryWithMembersDto>>()
            .MapWith(userGroups => userGroups
                .SelectMany(ug => GetAllUserGroupsFromHierarchy(ug, new HashSet<Guid>()))
                .DistinctBy(ug => ug.Summary.Id)
                .ToList());

        config.NewConfig<UserGroup, UserGroupSummaryDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Name, s => s.Name)
            .Map(d => d.AdminName, s => s.Admin.FullName, s => s.Admin != null);

        config.NewConfig<UserGroup, UserGroupSummaryWithMembersDto>()
            .Map(d => d.Summary.Id, s => s.Id)
            .Map(d => d.Summary.Name, s => s.Name)
            .Map(d => d.Summary.AdminName, s => s.Admin.FullName, s => s.Admin != null)
            .Map(d => d.Members, s => s.MembersWithAdmin);

        config.NewConfig<UserGroup, UserGroupHierarchyNodeDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Children, s => s.ChildrenGroups)
            .PreserveReference(true);

        config.NewConfig<User, CheckableUserSummaryDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.FirstName, s => s.FirstName)
            .Map(d => d.SecondName, s => s.SecondName)
            .Map(d => d.Patronymic, s => s.Patronymic)
            .Map(d => d.IsChecked, s => (s as CheckableUser).IsChecked, s => s is CheckableUser)
            .Map(d => d.IsChecked, s => false, s => !(s is CheckableUser));
        
        config.NewConfig<SingleMemberRights, CheckableUserSummaryDto>()
            .Map(d => d.Id, s => s.User.Id)
            .Map(d => d.FirstName, s => s.User.FirstName)
            .Map(d => d.SecondName, s => s.User.SecondName)
            .Map(d => d.Patronymic, s => s.User.Patronymic)
            .Map(d => d.IsChecked, s => (s.User as CheckableUser).IsChecked, s => s.User is CheckableUser)
            .Map(d => d.IsChecked, s => false, s => !(s.User is CheckableUser));
        
        config.NewConfig<UpdateAnnouncementContent, ContentForAnnouncementUpdatingDto>()
            .Map(d => d.Id, s => s.Announcement.Id)
            .Map(d => d.AuthorName, s => s.Announcement.Author.FullName)
            .Map(d => d.Content, s => s.Announcement.Content)
            .Map(d => d.ViewsCount, s => s.Announcement.ViewsCount)
            .Map(d => d.AudienceSize, s => s.Announcement.AudienceSize)
            .Map(d => d.AudienceHierarchy, s => MapAudienceHierarchy(s.Announcement.Audience, s.PotentialAudienceHierarchy))
            .Map(d => d.Surveys, s => s.Announcement.Attachments.OfType<Survey>())
            .Map(d => d.PublishedAt, s => s.Announcement.PublishedAt)
            .Map(d => d.HiddenAt, s => s.Announcement.HiddenAt)
            .Map(d => d.DelayedHidingAt, s => s.Announcement.DelayedHidingAt)
            .Map(d => d.DelayedPublishingAt, s => s.Announcement.DelayedPublishingAt);
    }



    private static List<UserGroupSummaryWithMembersDto> GetAllUserGroupsFromHierarchy(UserGroup userGroup, IReadOnlySet<Guid> actualAudienceIds)
    {
        var list = new List<UserGroupSummaryWithMembersDto>
        {
            MapUserGroup(userGroup, actualAudienceIds),
        };
        foreach (var child in userGroup.ChildrenGroups.OrderBy(ug => ug.Name))
            list.AddRange(GetAllUserGroupsFromHierarchy(child, actualAudienceIds));

        return list;
    }

    private static UsergroupHierarchyDto MapAudienceHierarchy(AnnouncementAudience audience, UserGroupList potentialAudience)
    {
        var audienceIdSet = audience
            .Select(u => u.Id)
            .ToHashSet();
        var flatUserGroupList = potentialAudience
            .SelectMany(ug => ug.FlattenUserGroupHierarchy())
            .Select(ug => MapUserGroup(ug, audienceIdSet))
            .ToList();
        var roots = potentialAudience.Adapt<List<UserGroupHierarchyNodeDto>>();
        
        return new UsergroupHierarchyDto
        {
            Roots = roots,
            Usergroups = flatUserGroupList
        };
    }

    private static UserGroupSummaryWithMembersDto MapUserGroup(UserGroup userGroup, IReadOnlySet<Guid> actualAudienceIds)
    {
        var mappedMembers = userGroup.MembersWithAdmin
            .Select(u => new CheckableUserSummaryDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                SecondName = u.SecondName,
                Patronymic = u.Patronymic,
                IsChecked = actualAudienceIds.Contains(u.Id)
            })
            .ToList();

        return new UserGroupSummaryWithMembersDto
        {
            Summary = userGroup.Adapt<UserGroupSummaryDto>(),
            Members = mappedMembers
        };
    }
}