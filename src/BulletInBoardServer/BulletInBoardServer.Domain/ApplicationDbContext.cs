using BulletInBoardServer.Domain.Models.Announcements;
using BulletInBoardServer.Domain.Models.Attachments.Surveys;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.Answers;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.Questions;
using BulletInBoardServer.Domain.Models.Attachments.Surveys.SurveyParticipation;
using BulletInBoardServer.Domain.Models.JoinEntities;
using BulletInBoardServer.Domain.Models.UserGroups;
using BulletInBoardServer.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using AnnouncementAudience = BulletInBoardServer.Domain.Models.JoinEntities.AnnouncementAudience;
using AttachmentBase = BulletInBoardServer.Domain.Models.Attachments.AttachmentBase;

namespace BulletInBoardServer.Domain;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; } = null!;
    public DbSet<UserGroup> UserGroups { get; init; } = null!;
    public DbSet<SingleMemberRights> MemberRights { get; init; } = null!;
    public DbSet<ChildUseGroup> ChildUseGroups { get; init; } = null!;
    public DbSet<Announcement> Announcements { get; init; } = null!;
    public DbSet<AnnouncementAudience> AnnouncementAudience { get; init; } = null!;
    public DbSet<AnnouncementAttachment> AnnouncementAttachmentJoins { get; init; } = null!;
    public DbSet<AttachmentBase> Attachments { get; init; } = null!;
    public DbSet<Survey> Surveys { get; init; } = null!;
    public DbSet<Question> Questions { get; init; } = null!;
    public DbSet<Answer> Answers { get; init; } = null!;
    public DbSet<Participation> Participation { get; init; } = null!;
    public DbSet<UserSelection> UserSelections { get; init; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAnnouncements(modelBuilder);
        ConfigureAttachments(modelBuilder);
        ConfigureUsers(modelBuilder);
        ConfigureAnnouncementAudience(modelBuilder);
        ConfigureUsergroups(modelBuilder);
        ConfigureMemberRights(modelBuilder);
        ConfigureSurveys(modelBuilder);
        ConfigureQuestions(modelBuilder);
        ConfigureAnswers(modelBuilder);
        ConfigureParticipation(modelBuilder);
        ConfigureUserSelections(modelBuilder);
    }



    private static void ConfigureAnnouncements(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.ToTable("announcements");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.AuthorId)
                .HasColumnName("author_id")
                .HasColumnType("uuid")
                .IsRequired();

            entity
                .HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId);

            entity.Property(e => e.AudienceSize)
                .HasColumnName("audience_size")
                .HasColumnType("integer")
                .IsRequired();

            entity.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.DelayedPublishingAt)
                .HasColumnName("delayed_publishing_at")
                .HasColumnType("timestamp")
                .IsRequired(false);

            entity.Property(e => e.ExpectsDelayedPublishing)
                .HasColumnName("expects_delayed_publishing")
                .HasComputedColumnSql(sql: "(delayed_publishing_at is not null)", true);

            entity.Property(e => e.DelayedHidingAt)
                .HasColumnName("delayed_hiding_at")
                .HasColumnType("timestamp")
                .IsRequired(false);

            entity.Property(e => e.ExpectsDelayedHiding)
                .HasColumnName("expects_delayed_hiding")
                .HasComputedColumnSql(sql: "(delayed_hiding_at is not null)", true);
            
            entity.Property(e => e.FirstlyPublishedAt)
                .HasColumnName("firstly_published_at")
                .HasColumnType("timestamp")
                .IsRequired(false);
            
            entity.Property(e => e.HasBeenPublished)
                .HasColumnName("has_been_published")
                .HasComputedColumnSql(sql: "(firstly_published_at is not null)", true);

            entity.Property(e => e.PublishedAt)
                .HasColumnName("published_at")
                .HasColumnType("timestamp")
                .IsRequired(false);

            entity.Property(e => e.IsPublished)
                .HasColumnName("is_published")
                .HasComputedColumnSql(sql: "(published_at is not null)", true);

            entity.Property(e => e.HiddenAt)
                .HasColumnName("hidden_at")
                .HasColumnType("timestamp")
                .IsRequired(false);

            entity.Property(e => e.IsHidden)
                .HasColumnName("is_hidden")
                .HasComputedColumnSql(sql: "(hidden_at is not null)", stored: true);

            // entity.Ignore(e => e.AudienceThreeNode); // remove
            entity.Ignore(e => e.ViewsCount);

            entity
                .HasMany(e => e.Audience)
                .WithMany()
                .UsingEntity<AnnouncementAudience>();
        });
    }

    private static void ConfigureAttachments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttachmentBase>(entity =>
        {
            entity
                .UseTptMappingStrategy()
                .ToTable("attachments");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            entity.Property(e => e.Type)
                .HasColumnName("type")
                .HasColumnType("text")
                .IsRequired();

            entity
                .HasMany(ab => ab.Announcements)
                .WithMany(e => e.Attachments)
                .UsingEntity<AnnouncementAttachment>(
                    join => join
                        .HasOne(e => e.Announcement)
                        .WithMany()
                        .HasForeignKey(e => e.AnnouncementId),
                    join => join
                        .HasOne(e => e.Attachment)
                        .WithMany()
                        .HasForeignKey(e => e.AttachmentId),
                    join =>
                    {
                        join.ToTable("announcements_attachments");
                        join.HasKey(e => new { e.AnnouncementId, e.AttachmentId });
                        join.Property(e => e.AnnouncementId)
                            .HasColumnName("announcement_id")
                            .HasColumnType("uuid");
                        join.Property(e => e.AttachmentId)
                            .HasColumnName("attachment_id")
                            .HasColumnType("uuid");

                        join
                            .HasOne(e => e.Announcement)
                            .WithMany()
                            .HasForeignKey(e => e.AnnouncementId);
                        join
                            .HasOne(e => e.Attachment)
                            .WithMany()
                            .HasForeignKey(e => e.AttachmentId);
                    });
        });
    }

    private static void ConfigureUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            entity.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.SecondName)
                .HasColumnName("second_name")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.Patronymic)
                .HasColumnName("patronymic")
                .HasColumnType("text")
                .IsRequired(false);
        });
    }

    private static void ConfigureAnnouncementAudience(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnnouncementAudience>(entity =>
        {
            entity.ToTable("announcement_audience");
            entity.HasKey(e => new { e.AnnouncementId, e.UserId });
            entity.Property(e => e.AnnouncementId)
                .HasColumnName("announcement_id")
                .HasColumnType("uuid");

            entity
                .HasOne(e => e.Announcement)
                .WithMany()
                .HasForeignKey(e => e.AnnouncementId);

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid");

            entity
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            entity.Property(e => e.Viewed)
                .HasColumnName("viewed")
                .HasColumnType("boolean");
        });
    }

    private static void ConfigureUsergroups(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.ToTable("usergroups");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.AdminId)
                .HasColumnName("admin_id")
                .HasColumnType("uuid");

            entity
                .HasOne(e => e.Admin)
                .WithMany()
                .HasForeignKey(e => e.AdminId)
                .IsRequired(false);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            entity
                .HasMany<UserGroup>()
                .WithMany(e => e.ChildrenGroups)
                .UsingEntity<ChildUseGroup>(
                    join => join
                        .HasOne(e => e.UserGroup)
                        .WithMany()
                        .HasForeignKey(e => e.UserGroupId),
                    join => join
                        .HasOne(e => e.ChildUserGroup)
                        .WithMany()
                        .HasForeignKey(e => e.ChildUserGroupId),
                    join =>
                    {
                        join.ToTable("child_usergroups");
                        join.HasKey(e => new { e.UserGroupId, e.ChildUserGroupId });
                        join.Property(e => e.UserGroupId)
                            .HasColumnName("usergroup_id")
                            .HasColumnType("uuid");
                        join.Property(e => e.ChildUserGroupId)
                            .HasColumnName("child_usergroup_id")
                            .HasColumnType("uuid");
                    }
                );

            entity.Ignore(e => e.MembersWithAdmin);
        });
    }

    private static void ConfigureMemberRights(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SingleMemberRights>(entity =>
        {
            entity.ToTable("member_rights");
            entity.HasKey(e => new { e.UserId, e.UserGroupId });
            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid");
            entity.Property(e => e.UserGroupId)
                .HasColumnName("usergroup_id")
                .HasColumnType("uuid");
            
            entity.Property(e => e.CanCreateAnnouncements)
                .HasColumnName("can_create_announcements")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanCreateSurveys)
                .HasColumnName("can_create_surveys")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanRuleUserGroupHierarchy)
                .HasColumnName("can_rule_usergroup_hierarchy")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanViewUserGroupDetails)
                .HasColumnName("can_view_usergroup_details")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanCreateUserGroups)
                .HasColumnName("can_create_usergroups")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanEditUserGroups)
                .HasColumnName("can_edit_usergroups")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanEditMembers)
                .HasColumnName("can_edit_members")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanEditMemberRights)
                .HasColumnName("can_edit_member_rights")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanEditUserGroupAdmin)
                .HasColumnName("can_edit_usergroup_admin")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            entity.Property(e => e.CanDeleteUserGroup)
                .HasColumnName("can_delete_usergroup")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            entity
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            entity
                .HasOne(e => e.UserGroup)
                .WithMany(e => e.MemberRights)
                .HasForeignKey(e => e.UserGroupId);
        });
    }

    private static void ConfigureSurveys(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Survey>(entity =>
        {
            entity.ToTable(
                "surveys",
                builder => builder.Property(e => e.Id).HasColumnName("id"));
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            entity.Property(e => e.VotersCount)
                .HasColumnName("voters_count")
                .HasColumnType("integer")
                .HasDefaultValue(0);

            entity.Property(e => e.IsOpen)
                .HasColumnName("is_open")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            entity.Property(e => e.IsAnonymous)
                .HasColumnName("is_anonymous")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            entity.Property(e => e.ResultsOpenBeforeClosing)
                .HasColumnName("results_open_before_closing")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            entity.Property(e => e.AutoClosingAt)
                .HasColumnName("auto_closing_at")
                .HasColumnType("timestamp")
                .IsRequired(false);

            entity.Property(e => e.ExpectsAutoClosing)
                .HasColumnName("expects_auto_closing")
                .HasComputedColumnSql(sql: "(auto_closing_at is not null)", true);

            entity.Property(e => e.VoteFinishedAt)
                .HasColumnName("vote_finished_at")
                .HasColumnType("timestamp")
                .IsRequired(false);

            entity.HasMany(e => e.Voters)
                .WithMany()
                .UsingEntity<Participation>();

            entity.Ignore(e => e.IsVotedByRequester);
        });
    }

    private static void ConfigureQuestions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("questions");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");
            
            entity.Property(e => e.Serial)
                .HasColumnName("serial")
                .HasColumnType("integer")
                .IsRequired();

            entity.Property(e => e.SurveyId)
                .HasColumnName("survey_id")
                .HasColumnType("uuid")
                .IsRequired();

            entity
                .HasOne(e => e.Survey)
                .WithMany(e => e.Questions)
                .HasForeignKey(e => e.SurveyId)
                .IsRequired();

            entity.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.IsMultipleChoiceAllowed)
                .HasColumnName("is_multiple_choice_allowed")
                .HasColumnType("boolean");
        });
    }

    private static void ConfigureAnswers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.ToTable("answers");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd();
            
            entity.Property(e => e.Serial)
                .HasColumnName("serial")
                .HasColumnType("integer")
                .IsRequired();

            entity.Property(e => e.QuestionId)
                .HasColumnName("question_id")
                .HasColumnType("uuid")
                .IsRequired();

            entity
                .HasOne(e => e.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(e => e.QuestionId)
                .IsRequired();

            entity.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.VotersCount)
                .HasColumnName("voters_count")
                .HasColumnType("integer")
                .HasDefaultValue(0);

            entity.HasMany(a => a.Participation)
                .WithMany(p => p.Answers)
                .UsingEntity<UserSelection>();
        });
    }

    private static void ConfigureParticipation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participation>(entity =>
        {
            entity.ToTable("participation");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uuid");

            entity
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            entity.Property(e => e.SurveyId)
                .HasColumnName("survey_id")
                .HasColumnType("uuid");

            entity
                .HasOne(e => e.Survey)
                .WithMany()
                .HasForeignKey(e => e.SurveyId)
                .IsRequired();
        });
    }

    private static void ConfigureUserSelections(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserSelection>(entity =>
        {
            entity.ToTable("user_selections");
            entity.HasKey(e => new { e.ParticipationId, e.AnswerId });
            entity.Property(e => e.ParticipationId)
                .HasColumnName("participation_id")
                .HasColumnType("uuid");
            entity.Property(e => e.AnswerId)
                .HasColumnName("answer_id")
                .HasColumnType("uuid");

            entity
                .HasOne(e => e.Participation)
                .WithMany()
                .HasForeignKey(e => e.ParticipationId);

            entity
                .HasOne(e => e.Answer)
                .WithMany()
                .HasForeignKey(e => e.AnswerId);
        });
    }
}