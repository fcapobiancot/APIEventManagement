using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public string? Address { get; set; }

    public int? Capacity { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrivate { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? IsPaid { get; set; }

    public decimal? Price { get; set; }

    public int? Category { get; set; }

    public virtual Category? CategoryNavigation { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<PrivateEventAccess> PrivateEventAccesses { get; set; } = new List<PrivateEventAccess>();

    public virtual ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
}
