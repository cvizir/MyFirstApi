using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class Article
{
    public int No { get; set; }

    public string NewsCode { get; set; } = null!;

    public string NewsType { get; set; } = null!;

    public DateTime Uptime { get; set; }

    public DateTime Wttime { get; set; }

    public string Author { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string YouTubeCode { get; set; } = null!;

    public string WebUrl { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string Info { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Photo { get; set; } = null!;

    public string Ps { get; set; } = null!;

    public int ClickNum { get; set; }

    public int MSort { get; set; }

    public int TopIshow { get; set; }

    public int Ishow { get; set; }
}
