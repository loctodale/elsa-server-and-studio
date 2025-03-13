using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Specialty
{
    public Guid Id { get; set; }

    public Guid? ProfessionId { get; set; }

    public string? SpecialtyName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Idea> Ideas { get; set; } = new List<Idea>();

    public virtual Profession? Profession { get; set; }

    public virtual ICollection<ProfileStudent> ProfileStudents { get; set; } = new List<ProfileStudent>();
}
