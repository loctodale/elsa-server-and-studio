using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class RefreshToken
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? Token { get; set; }

    public string? KeyId { get; set; }

    public string? PublicKey { get; set; }

    public string? UserAgent { get; set; }

    public string? IpAddress { get; set; }

    public DateTime? Expiry { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual User? User { get; set; }
}
