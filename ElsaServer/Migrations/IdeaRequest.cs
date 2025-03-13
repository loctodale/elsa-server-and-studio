using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class IdeaRequest
{
    public Guid Id { get; set; }

    public Guid? IdeaId { get; set; }

    public Guid? ReviewerId { get; set; }

    public string? Content { get; set; }

    public DateTime? ProcessDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public string? Status { get; set; }

    public virtual Idea? Idea { get; set; }

    public virtual User? Reviewer { get; set; }
}
