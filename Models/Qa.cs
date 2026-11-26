using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class Qa
{
    public int No { get; set; }

    public string QaCode { get; set; } = null!;

    public DateTime Uptime { get; set; }

    public string CatId { get; set; } = null!;

    public string Question { get; set; } = null!;

    public string Ans { get; set; } = null!;

    public int MSort { get; set; }

    public int Ishow { get; set; }
}
