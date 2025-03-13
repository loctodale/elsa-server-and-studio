using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Notification
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public bool IsRead { get; set; }

    public virtual User? User { get; set; }
}
