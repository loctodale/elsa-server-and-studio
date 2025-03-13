using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Role
{
    public Guid Id { get; set; }

    public string? RoleName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<UserXrole> UserXroles { get; set; } = new List<UserXrole>();
}
