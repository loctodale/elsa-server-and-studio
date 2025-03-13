using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Invitation
{
    public Guid Id { get; set; }

    public Guid? ProjectId { get; set; }

    public Guid? SenderId { get; set; }

    public Guid? ReceiverId { get; set; }

    public string? Status { get; set; }

    public string? Type { get; set; }

    public string? Content { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual Project? Project { get; set; }

    public virtual User? Receiver { get; set; }

    public virtual User? Sender { get; set; }
}
