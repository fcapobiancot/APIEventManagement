using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class Rol
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
