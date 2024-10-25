using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class UserEvent
{
    public int UserId { get; set; }

    public int EventId { get; set; }

    public bool? UserMarkAttendance { get; set; }

    public bool? OrganizerMarkAttendance { get; set; }

    public bool? IsCreator { get; set; }

    public bool? HasPaid { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
