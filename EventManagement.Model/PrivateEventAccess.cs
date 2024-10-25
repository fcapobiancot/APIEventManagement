using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class PrivateEventAccess
{
    public int UserId { get; set; }

    public int EventId { get; set; }

    public bool? HasAccess { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
