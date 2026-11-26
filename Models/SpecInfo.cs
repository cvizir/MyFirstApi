using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class SpecInfo
{
    public int No { get; set; }

    public string SpecCode { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string ImgUrl { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string SpecType { get; set; } = null!;

    public string ShowType { get; set; } = null!;

    public int Ishow { get; set; }
}
