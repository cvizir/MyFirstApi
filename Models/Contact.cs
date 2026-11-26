using System;
using System.Collections.Generic;

namespace MyFirstApi.Models;

public partial class Contact
{
    public int No { get; set; }

    public DateTime Uptime { get; set; }

    public DateTime PostTime { get; set; }

    public string Subject { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public string Mphone { get; set; } = null!;

    public string Addr { get; set; } = null!;

    public string Msg { get; set; } = null!;

    public string ContactCode { get; set; } = null!;
}
