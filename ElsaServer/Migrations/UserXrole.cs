using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class UserXrole
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? RoleId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
