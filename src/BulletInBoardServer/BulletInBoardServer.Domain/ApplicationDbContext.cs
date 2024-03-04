using BulletInBoardServer.Domain.Models.AnnouncementCategories;
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
using File = BulletInBoardServer.Domain.Models.Attachments.File;

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
    public DbSet<File> Files { get; init; } = null!;
    public DbSet<Survey> Surveys { get; init; } = null!;
    public DbSet<Question> Questions { get; init; } = null!;
    public DbSet<Answer> Answers { get; init; } = null!;
    public DbSet<Participation> Participation { get; init; } = null!;
    public DbSet<UserSelection> UserSelections { get; init; } = null!;
    public DbSet<AnnouncementCategory> AnnouncementCategories { get; init; } = null!;
    public DbSet<AnnouncementAnnouncementCategory> AnnouncementCategoryJoins { get; init; } = null!;
    public DbSet<AnnouncementCategorySubscription> AnnouncementCategorySubscriptions { get; init; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAnnouncements(modelBuilder);
        ConfigureAttachments(modelBuilder);
        ConfigureFiles(modelBuilder);
        ConfigureUsers(modelBuilder);
        ConfigureAnnouncementAudience(modelBuilder);
        ConfigureUsergroups(modelBuilder);
        ConfigureMemberRights(modelBuilder);
        ConfigureAnnouncementCategories(modelBuilder);
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

            entity.Ignore(e => e.ViewsCount);

            entity
                .HasMany(e => e.Categories)
                .WithMany()
                .UsingEntity<AnnouncementAnnouncementCategory>(
                    join => join
                        .HasOne(e => e.AnnouncementCategory)
                        .WithMany()
                        .HasForeignKey(e => e.AnnouncementCategoryId),
                    join => join
                        .HasOne(e => e.Announcement)
                        .WithMany()
                        .HasForeignKey(e => e.AnnouncementId),
                    join =>
                    {
                        join.ToTable("announcements_announcement_categories");
                        join.HasKey(e => new { e.AnnouncementId, e.AnnouncementCategoryId });
                        join.Property(e => e.AnnouncementId)
                            .HasColumnName("announcement_id")
                            .HasColumnType("uuid");
                        join.Property(e => e.AnnouncementCategoryId)
                            .HasColumnName("announcement_category_id")
                            .HasColumnType("uuid");
                    }
                );

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

    private static void ConfigureFiles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>(entity =>
        {
            entity.ToTable(
                "files",
                builder => builder.Property(e => e.Id).HasColumnName("id"));
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            entity.Property(e => e.UploaderId)
                .HasColumnName("uploader_id")
                .HasColumnType("uuid")
                .IsRequired();
            entity
                .HasOne(e => e.Uploader)
                .WithMany()
                .HasForeignKey(e => e.UploaderId);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.Hash)
                .HasColumnName("hash")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.LinksCount)
                .HasColumnName("links_count")
                .HasColumnType("integer")
                .HasDefaultValue(0);
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

    private static void ConfigureAnnouncementCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnnouncementCategory>(entity =>
        {
            entity.ToTable("announcement_categories");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            entity.Property(e => e.ColorHex)
                .HasColumnName("color_hex")
                .HasColumnType("text")
                .IsRequired();

            entity
                .HasMany(e => e.Subscribers)
                .WithMany()
                .UsingEntity<AnnouncementCategorySubscription>(
                    join => join
                        .HasOne(e => e.Subscriber) 
                        .WithMany()
                        .HasForeignKey(e => e.SubscriberId),
                    join => join
                        .HasOne(e => e.AnnouncementCategory)
                        .WithMany()
                        .HasForeignKey(e => e.AnnouncementCategoryId),
                    join =>
                    {
                        join.ToTable("announcement_categories_subscribers");
                        join.HasKey(e => new { e.AnnouncementCategoryId, e.SubscriberId });
                        join.Property(e => e.AnnouncementCategoryId)
                            .HasColumnName("announcement_category_id")
                            .HasColumnType("uuid");
                        join.Property(e => e.SubscriberId)
                            .HasColumnName("subscriber_id")
                            .HasColumnType("uuid");
                    }
                );
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
                .HasColumnType("boolean");

            entity.Property(e => e.IsAnonymous)
                .HasColumnName("is_anonymous")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            entity.Property(e => e.AutoClosingAt)
                .HasColumnName("auto_closing_at")
                .HasColumnType("timestamp")
                .IsRequired(false);

            entity.Property(e => e.ExpectsAutoClosing)
                .HasColumnName("expects_auto_closing")
                .HasComputedColumnSql(sql: "(auto_closing_at is not null)", true);

            entity.HasMany(e => e.Voters)
                .WithMany()
                .UsingEntity<Participation>();
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