using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Lock
{
    public string Resource { get; set; } = null!;

    public int Updatecount { get; set; }

    public DateTime? Acquired { get; set; }
}
