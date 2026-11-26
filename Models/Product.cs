using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class Product
{
    public int No { get; set; }

    public DateTime Uptime { get; set; }

    public string ProductCode { get; set; } = null!;

    public string PdTitle { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int PdStock { get; set; }

    public string PdcatCode { get; set; } = null!;

    public int OPrice { get; set; }

    public int Price { get; set; }

    public int HotItem { get; set; }

    public string YouTubeCode { get; set; } = null!;

    public string PdInfo { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public string Ps { get; set; } = null!;

    public DateTime? ReleaseDate { get; set; }

    public int MSort { get; set; }

    public int Ishow { get; set; }
}
