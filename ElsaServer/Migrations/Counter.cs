﻿using System;
using System.Collections.Generic;

namespace ElsaServer.Migrations;

public partial class Counter
{
    public long Id { get; set; }

    public string Key { get; set; } = null!;

    public long Value { get; set; }

    public DateTime? Expireat { get; set; }
}
