using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class User
{
    public Guid Id { get; set; }

    public string? Gender { get; set; }

    public string? Cache { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Avatar { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Department { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<BlogCv> BlogCvs { get; set; } = new List<BlogCv>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<IdeaHistory> IdeaHistories { get; set; } = new List<IdeaHistory>();

    public virtual ICollection<IdeaHistoryRequest> IdeaHistoryRequests { get; set; } = new List<IdeaHistoryRequest>();

    public virtual ICollection<Idea> IdeaMentors { get; set; } = new List<Idea>();

    public virtual ICollection<Idea> IdeaOwners { get; set; } = new List<Idea>();

    public virtual ICollection<IdeaRequest> IdeaRequests { get; set; } = new List<IdeaRequest>();

    public virtual ICollection<Idea> IdeaSubMentors { get; set; } = new List<Idea>();

    public virtual ICollection<Invitation> InvitationReceivers { get; set; } = new List<Invitation>();

    public virtual ICollection<Invitation> InvitationSenders { get; set; } = new List<Invitation>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ProfileStudent? ProfileStudent { get; set; }

    public virtual ICollection<Project> ProjectLeaders { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectUsers { get; set; } = new List<Project>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<SkillProfile> SkillProfiles { get; set; } = new List<SkillProfile>();

    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();

    public virtual ICollection<UserXrole> UserXroles { get; set; } = new List<UserXrole>();
}
