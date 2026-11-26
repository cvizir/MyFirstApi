using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class Admin
{
    public int No { get; set; }

    public DateTime Uptime { get; set; }

    public string AdminIndex { get; set; } = null!;

    public string AdminCode { get; set; } = null!;

    public string AdminId { get; set; } = null!;

    public string AdminPsw { get; set; } = null!;

    public string AdminPv { get; set; } = null!;

    public int Ishow { get; set; }
}
