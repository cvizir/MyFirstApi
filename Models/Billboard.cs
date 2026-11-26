using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class Billboard
{
    public int No { get; set; }

    public DateTime Uptime { get; set; }

    public string BillboardCatCode { get; set; } = null!;

    public string BillboardCode { get; set; } = null!;

    public int DelSw { get; set; }

    public string IndexName { get; set; } = null!;

    public string IndexCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string BdClass { get; set; } = null!;

    public string MType { get; set; } = null!;

    public string Info { get; set; } = null!;

    public string PicSize { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string WebCode { get; set; } = null!;

    public string WebUrl { get; set; } = null!;

    public string Ps { get; set; } = null!;

    public int MSort { get; set; }

    public int Ishow { get; set; }
}
