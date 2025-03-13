using System;
using System.Collections.Generic;
using ElsaServer.Migrations;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ElsaServer.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aggregatedcounter> Aggregatedcounters { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogCv> BlogCvs { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<Idea> Ideas { get; set; }

    public virtual DbSet<IdeaHistory> IdeaHistories { get; set; }

    public virtual DbSet<IdeaHistoryRequest> IdeaHistoryRequests { get; set; }

    public virtual DbSet<IdeaRequest> IdeaRequests { get; set; }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Jobparameter> Jobparameters { get; set; }

    public virtual DbSet<Jobqueue> Jobqueues { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Lock> Locks { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<ProfileStudent> ProfileStudents { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<SkillProfile> SkillProfiles { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserXrole> UserXroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
         optionsBuilder.UseNpgsql(configuration.GetSection("ConnectionStrings").Value);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aggregatedcounter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aggregatedcounter_pkey");

            entity.ToTable("aggregatedcounter", "hangfire");

            entity.HasIndex(e => e.Key, "aggregatedcounter_key_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog");

            entity.HasIndex(e => e.ProjectId, "IX_Blog_ProjectId");

            entity.HasIndex(e => e.UserId, "IX_Blog_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Project).WithMany(p => p.Blogs).HasForeignKey(d => d.ProjectId);

            entity.HasOne(d => d.User).WithMany(p => p.Blogs).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BlogCv>(entity =>
        {
            entity.ToTable("BlogCv");

            entity.HasIndex(e => e.BlogId, "IX_BlogCv_BlogId");

            entity.HasIndex(e => e.UserId, "IX_BlogCv_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.FileCv).HasMaxLength(1);

            entity.HasOne(d => d.Blog).WithMany(p => p.BlogCvs).HasForeignKey(d => d.BlogId);

            entity.HasOne(d => d.User).WithMany(p => p.BlogCvs).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.HasIndex(e => e.BlogId, "IX_Comment_BlogId");

            entity.HasIndex(e => e.UserId, "IX_Comment_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Blog).WithMany(p => p.Comments).HasForeignKey(d => d.BlogId);

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("counter_pkey");

            entity.ToTable("counter", "hangfire");

            entity.HasIndex(e => e.Expireat, "ix_hangfire_counter_expireat");

            entity.HasIndex(e => e.Key, "ix_hangfire_counter_key");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.HasIndex(e => e.ReviewId, "IX_Feedback_ReviewId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Review).WithMany(p => p.Feedbacks).HasForeignKey(d => d.ReviewId);
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hash_pkey");

            entity.ToTable("hash", "hangfire");

            entity.HasIndex(e => new { e.Key, e.Field }, "hash_key_field_key").IsUnique();

            entity.HasIndex(e => e.Expireat, "ix_hangfire_hash_expireat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Field).HasColumnName("field");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Idea>(entity =>
        {
            entity.ToTable("Idea");

            entity.HasIndex(e => e.MentorId, "IX_Idea_MentorId");

            entity.HasIndex(e => e.OwnerId, "IX_Idea_OwnerId");

            entity.HasIndex(e => e.SemesterId, "IX_Idea_SemesterId");

            entity.HasIndex(e => e.SpecialtyId, "IX_Idea_SpecialtyId");

            entity.HasIndex(e => e.SubMentorId, "IX_Idea_SubMentorId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.IsEnterpriseTopic).HasDefaultValue(false);
            entity.Property(e => e.IsExistedTeam).HasDefaultValue(false);
            entity.Property(e => e.MaxTeamSize).HasDefaultValue(0);

            entity.HasOne(d => d.Mentor).WithMany(p => p.IdeaMentors).HasForeignKey(d => d.MentorId);

            entity.HasOne(d => d.Owner).WithMany(p => p.IdeaOwners).HasForeignKey(d => d.OwnerId);

            entity.HasOne(d => d.Semester).WithMany(p => p.Ideas).HasForeignKey(d => d.SemesterId);

            entity.HasOne(d => d.Specialty).WithMany(p => p.Ideas).HasForeignKey(d => d.SpecialtyId);

            entity.HasOne(d => d.SubMentor).WithMany(p => p.IdeaSubMentors).HasForeignKey(d => d.SubMentorId);
        });

        modelBuilder.Entity<IdeaHistory>(entity =>
        {
            entity.ToTable("IdeaHistory");

            entity.HasIndex(e => e.CouncilId, "IX_IdeaHistory_CouncilId");

            entity.HasIndex(e => e.IdeaId, "IX_IdeaHistory_IdeaId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Council).WithMany(p => p.IdeaHistories).HasForeignKey(d => d.CouncilId);

            entity.HasOne(d => d.Idea).WithMany(p => p.IdeaHistories).HasForeignKey(d => d.IdeaId);
        });

        modelBuilder.Entity<IdeaHistoryRequest>(entity =>
        {
            entity.ToTable("IdeaHistoryRequest");

            entity.HasIndex(e => e.IdeaHistoryId, "IX_IdeaHistoryRequest_IdeaHistoryId");

            entity.HasIndex(e => e.ReviewerId, "IX_IdeaHistoryRequest_ReviewerId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.IdeaHistory).WithMany(p => p.IdeaHistoryRequests).HasForeignKey(d => d.IdeaHistoryId);

            entity.HasOne(d => d.Reviewer).WithMany(p => p.IdeaHistoryRequests).HasForeignKey(d => d.ReviewerId);
        });

        modelBuilder.Entity<IdeaRequest>(entity =>
        {
            entity.ToTable("IdeaRequest");

            entity.HasIndex(e => e.IdeaId, "IX_IdeaRequest_IdeaId");

            entity.HasIndex(e => e.ReviewerId, "IX_IdeaRequest_ReviewerId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Idea).WithMany(p => p.IdeaRequests).HasForeignKey(d => d.IdeaId);

            entity.HasOne(d => d.Reviewer).WithMany(p => p.IdeaRequests).HasForeignKey(d => d.ReviewerId);
        });

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.ToTable("Invitation");

            entity.HasIndex(e => e.ProjectId, "IX_Invitation_ProjectId");

            entity.HasIndex(e => e.ReceiverId, "IX_Invitation_ReceiverId");

            entity.HasIndex(e => e.SenderId, "IX_Invitation_SenderId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Project).WithMany(p => p.Invitations).HasForeignKey(d => d.ProjectId);

            entity.HasOne(d => d.Receiver).WithMany(p => p.InvitationReceivers).HasForeignKey(d => d.ReceiverId);

            entity.HasOne(d => d.Sender).WithMany(p => p.InvitationSenders).HasForeignKey(d => d.SenderId);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_pkey");

            entity.ToTable("job", "hangfire");

            entity.HasIndex(e => e.Expireat, "ix_hangfire_job_expireat");

            entity.HasIndex(e => e.Statename, "ix_hangfire_job_statename");

            entity.HasIndex(e => e.Statename, "ix_hangfire_job_statename_is_not_null").HasFilter("(statename IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Arguments)
                .HasColumnType("jsonb")
                .HasColumnName("arguments");
            entity.Property(e => e.Createdat).HasColumnName("createdat");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Invocationdata)
                .HasColumnType("jsonb")
                .HasColumnName("invocationdata");
            entity.Property(e => e.Stateid).HasColumnName("stateid");
            entity.Property(e => e.Statename).HasColumnName("statename");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
        });

        modelBuilder.Entity<Jobparameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobparameter_pkey");

            entity.ToTable("jobparameter", "hangfire");

            entity.HasIndex(e => new { e.Jobid, e.Name }, "ix_hangfire_jobparameter_jobidandname");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Jobid).HasColumnName("jobid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Job).WithMany(p => p.Jobparameters)
                .HasForeignKey(d => d.Jobid)
                .HasConstraintName("jobparameter_jobid_fkey");
        });

        modelBuilder.Entity<Jobqueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobqueue_pkey");

            entity.ToTable("jobqueue", "hangfire");

            entity.HasIndex(e => new { e.Fetchedat, e.Queue, e.Jobid }, "ix_hangfire_jobqueue_fetchedat_queue_jobid").HasNullSortOrder(new[] { NullSortOrder.NullsFirst, NullSortOrder.NullsLast, NullSortOrder.NullsLast });

            entity.HasIndex(e => new { e.Jobid, e.Queue }, "ix_hangfire_jobqueue_jobidandqueue");

            entity.HasIndex(e => new { e.Queue, e.Fetchedat }, "ix_hangfire_jobqueue_queueandfetchedat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fetchedat).HasColumnName("fetchedat");
            entity.Property(e => e.Jobid).HasColumnName("jobid");
            entity.Property(e => e.Queue).HasColumnName("queue");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.ToTable("Like");

            entity.HasIndex(e => e.BlogId, "IX_Like_BlogId");

            entity.HasIndex(e => e.UserId, "IX_Like_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Blog).WithMany(p => p.Likes).HasForeignKey(d => d.BlogId);

            entity.HasOne(d => d.User).WithMany(p => p.Likes).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_pkey");

            entity.ToTable("list", "hangfire");

            entity.HasIndex(e => e.Expireat, "ix_hangfire_list_expireat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Lock>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lock", "hangfire");

            entity.HasIndex(e => e.Resource, "lock_resource_key").IsUnique();

            entity.Property(e => e.Acquired).HasColumnName("acquired");
            entity.Property(e => e.Resource).HasColumnName("resource");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.HasIndex(e => e.UserId, "IX_Notification_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.IsRead).HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.ToTable("Profession");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ProfileStudent>(entity =>
        {
            entity.ToTable("ProfileStudent");

            entity.HasIndex(e => e.SemesterId, "IX_ProfileStudent_SemesterId");

            entity.HasIndex(e => e.SpecialtyId, "IX_ProfileStudent_SpecialtyId");

            entity.HasIndex(e => e.UserId, "IX_ProfileStudent_UserId").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Semester).WithMany(p => p.ProfileStudents).HasForeignKey(d => d.SemesterId);

            entity.HasOne(d => d.Specialty).WithMany(p => p.ProfileStudents).HasForeignKey(d => d.SpecialtyId);

            entity.HasOne(d => d.User).WithOne(p => p.ProfileStudent).HasForeignKey<ProfileStudent>(d => d.UserId);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.HasIndex(e => e.IdeaId, "IX_Project_IdeaId").IsUnique();

            entity.HasIndex(e => e.LeaderId, "IX_Project_LeaderId");

            entity.HasIndex(e => e.UserId, "IX_Project_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Idea).WithOne(p => p.Project).HasForeignKey<Project>(d => d.IdeaId);

            entity.HasOne(d => d.Leader).WithMany(p => p.ProjectLeaders).HasForeignKey(d => d.LeaderId);

            entity.HasOne(d => d.User).WithMany(p => p.ProjectUsers).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.ToTable("Rate");

            entity.HasIndex(e => e.RateById, "IX_Rate_RateById");

            entity.HasIndex(e => e.RateForId, "IX_Rate_RateForId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.RateBy).WithMany(p => p.RateRateBies).HasForeignKey(d => d.RateById);

            entity.HasOne(d => d.RateFor).WithMany(p => p.RateRateFors).HasForeignKey(d => d.RateForId);
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken");

            entity.HasIndex(e => e.UserId, "IX_RefreshToken_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.HasIndex(e => e.ProjectId, "IX_Review_ProjectId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Project).WithMany(p => p.Reviews).HasForeignKey(d => d.ProjectId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        });

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("schema_pkey");

            entity.ToTable("schema", "hangfire");

            entity.Property(e => e.Version)
                .ValueGeneratedNever()
                .HasColumnName("version");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.ToTable("Semester");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("server_pkey");

            entity.ToTable("server", "hangfire");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");
            entity.Property(e => e.Lastheartbeat).HasColumnName("lastheartbeat");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("set_pkey");

            entity.ToTable("set", "hangfire");

            entity.HasIndex(e => e.Expireat, "ix_hangfire_set_expireat");

            entity.HasIndex(e => new { e.Key, e.Score }, "ix_hangfire_set_key_score");

            entity.HasIndex(e => new { e.Key, e.Value }, "set_key_value_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<SkillProfile>(entity =>
        {
            entity.ToTable("SkillProfile");

            entity.HasIndex(e => e.ProfileStudentId, "IX_SkillProfile_ProfileStudentId");

            entity.HasIndex(e => e.UserId, "IX_SkillProfile_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.ProfileStudent).WithMany(p => p.SkillProfiles).HasForeignKey(d => d.ProfileStudentId);

            entity.HasOne(d => d.User).WithMany(p => p.SkillProfiles).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.ToTable("Specialty");

            entity.HasIndex(e => e.ProfessionId, "IX_Specialty_ProfessionId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Profession).WithMany(p => p.Specialties).HasForeignKey(d => d.ProfessionId);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("state_pkey");

            entity.ToTable("state", "hangfire");

            entity.HasIndex(e => e.Jobid, "ix_hangfire_state_jobid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat).HasColumnName("createdat");
            entity.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");
            entity.Property(e => e.Jobid).HasColumnName("jobid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");

            entity.HasOne(d => d.Job).WithMany(p => p.States)
                .HasForeignKey(d => d.Jobid)
                .HasConstraintName("state_jobid_fkey");
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.ToTable("TeamMember");

            entity.HasIndex(e => e.ProjectId, "IX_TeamMember_ProjectId");

            entity.HasIndex(e => e.UserId, "IX_TeamMember_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Project).WithMany(p => p.TeamMembers).HasForeignKey(d => d.ProjectId);

            entity.HasOne(d => d.User).WithMany(p => p.TeamMembers).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        });

        modelBuilder.Entity<UserXrole>(entity =>
        {
            entity.ToTable("UserXRole");

            entity.HasIndex(e => e.RoleId, "IX_UserXRole_RoleId");

            entity.HasIndex(e => e.UserId, "IX_UserXRole_UserId");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            entity.HasOne(d => d.Role).WithMany(p => p.UserXroles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.UserXroles).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
