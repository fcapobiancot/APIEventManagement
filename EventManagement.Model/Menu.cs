using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class Menu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Icon { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Rol> Roles { get; set; } = new List<Rol>();
}
