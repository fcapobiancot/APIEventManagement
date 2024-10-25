using System;
using System.Collections.Generic;

namespace EventManagement.Model;

public partial class Comment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? EventId { get; set; }

    public string Comment1 { get; set; } = null!;

    public DateTime? CommentDate { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
