using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Semester
{
    public Guid Id { get; set; }

    public string? SemesterCode { get; set; }

    public string? SemesterName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public string? SemesterPrefixName { get; set; }

    public virtual ICollection<Idea> Ideas { get; set; } = new List<Idea>();

    public virtual ICollection<ProfileStudent> ProfileStudents { get; set; } = new List<ProfileStudent>();
}
