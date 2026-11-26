using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class SpecGroup
{
    public int No { get; set; }

    public string SpecGroupCode { get; set; } = null!;

    public string PdcatCode { get; set; } = null!;

    public string SpecCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Ishow { get; set; }
}
