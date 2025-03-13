using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Idea
{
    public Guid Id { get; set; }

    public Guid? OwnerId { get; set; }

    public Guid? SemesterId { get; set; }

    public Guid? SubMentorId { get; set; }

    public string? Type { get; set; }

    public string? EnterpriseName { get; set; }

    public string? IdeaCode { get; set; }

    public string? VietNamName { get; set; }

    public string? EnglishName { get; set; }

    public string? Description { get; set; }

    public string? File { get; set; }

    public string? Status { get; set; }

    public bool IsExistedTeam { get; set; }

    public int MaxTeamSize { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public string? Abbreviations { get; set; }

    public Guid? SpecialtyId { get; set; }

    public bool IsEnterpriseTopic { get; set; }

    public Guid? MentorId { get; set; }

    public virtual ICollection<IdeaHistory> IdeaHistories { get; set; } = new List<IdeaHistory>();

    public virtual ICollection<IdeaRequest> IdeaRequests { get; set; } = new List<IdeaRequest>();

    public virtual User? Mentor { get; set; }

    public virtual User? Owner { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual Specialty? Specialty { get; set; }

    public virtual User? SubMentor { get; set; }
}
