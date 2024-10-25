using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class Payment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? EventId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
