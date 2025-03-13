using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class SkillProfile
{
    public Guid Id { get; set; }

    public Guid? ProfileStudentId { get; set; }

    public string? FullSkill { get; set; }

    public string? Json { get; set; }

    public Guid? UserId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual ProfileStudent? ProfileStudent { get; set; }

    public virtual User? User { get; set; }
}
