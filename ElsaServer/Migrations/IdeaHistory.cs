using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class IdeaHistory
{
    public Guid Id { get; set; }

    public Guid? IdeaId { get; set; }

    public Guid? CouncilId { get; set; }

    public string? FileUpdate { get; set; }

    public string? Status { get; set; }

    public int ReviewStage { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual User? Council { get; set; }

    public virtual Idea? Idea { get; set; }

    public virtual ICollection<IdeaHistoryRequest> IdeaHistoryRequests { get; set; } = new List<IdeaHistoryRequest>();
}
