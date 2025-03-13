using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class TeamMember
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ProjectId { get; set; }

    public string? Role { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? LeaveDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public string? Status { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<Rate> RateRateBies { get; set; } = new List<Rate>();

    public virtual ICollection<Rate> RateRateFors { get; set; } = new List<Rate>();

    public virtual User? User { get; set; }
}
