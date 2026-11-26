using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class BillboardCat
{
    public int No { get; set; }

    public string BillboardCatCode { get; set; } = null!;

    public string IndexCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string SltLg { get; set; } = null!;

    public int LimitNum { get; set; }

    public string WebUrl { get; set; } = null!;

    public string ListUrl { get; set; } = null!;

    public string EditUrl { get; set; } = null!;

    public string SaveUrl { get; set; } = null!;

    public string Ps { get; set; } = null!;

    public int DelSw { get; set; }

    public int MSort { get; set; }

    public int Ishow { get; set; }
}
