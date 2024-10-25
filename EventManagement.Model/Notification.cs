using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class Notification
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? EventId { get; set; }

    public string? Message { get; set; }

    public string? Type { get; set; }

    public DateTime? NotificationDate { get; set; }

    public bool? IsRead { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
