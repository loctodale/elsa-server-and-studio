using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Review
{
    public Guid Id { get; set; }

    public Guid? ProjectId { get; set; }

    public int Number { get; set; }

    public string? Description { get; set; }

    public string? FileUpload { get; set; }

    public string? Reviewer1 { get; set; }

    public string? Reviewer2 { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Project? Project { get; set; }
}
