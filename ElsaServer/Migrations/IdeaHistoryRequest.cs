using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class IdeaHistoryRequest
{
    public Guid Id { get; set; }

    public Guid? IdeaHistoryId { get; set; }

    public Guid? ReviewerId { get; set; }

    public string? Content { get; set; }

    public string? Status { get; set; }

    public DateTime? ProcessDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual IdeaHistory? IdeaHistory { get; set; }

    public virtual User? Reviewer { get; set; }
}
