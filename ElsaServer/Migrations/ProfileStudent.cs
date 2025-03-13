using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class ProfileStudent
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Bio { get; set; }

    public string? Code { get; set; }

    public bool IsQualifiedForAcademicProject { get; set; }

    public string? Achievement { get; set; }

    public string? ExperienceProject { get; set; }

    public string? Interest { get; set; }

    public string? FileCv { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public Guid? SemesterId { get; set; }

    public Guid? SpecialtyId { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual ICollection<SkillProfile> SkillProfiles { get; set; } = new List<SkillProfile>();

    public virtual Specialty? Specialty { get; set; }

    public virtual User? User { get; set; }
}
