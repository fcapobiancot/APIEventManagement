using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ProfilePic { get; set; }

    public string? Socials { get; set; }

    public int? RoleId { get; set; }


    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<PrivateEventAccess> PrivateEventAccesses { get; set; } = new List<PrivateEventAccess>();

    public virtual Rol? Role { get; set; }

    public virtual ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
}
