using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Rate
{
    public Guid Id { get; set; }

    public Guid? RateForId { get; set; }

    public Guid? RateById { get; set; }

    public int NumbOfStar { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual TeamMember? RateBy { get; set; }

    public virtual TeamMember? RateFor { get; set; }
}
