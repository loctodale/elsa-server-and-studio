using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Feedback
{
    public Guid Id { get; set; }

    public Guid? ReviewId { get; set; }

    public string? Content { get; set; }

    public string? Description { get; set; }

    public string? FileUpload { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual Review? Review { get; set; }
}
