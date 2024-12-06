using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EventCreationDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public string? Address { get; set; }
    public int? Capacity { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsPaid { get; set; }
    public decimal? Price { get; set; }
    public int Category { get; set; }
    public List<int>? PrivateEventAccessUserIds { get; set; }
    public int CreatorUserId { get; set; } // Nuevo campo
}

