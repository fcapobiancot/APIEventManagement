using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DTO
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } 

        public string? Email { get; set; } 

        public string? RolDescription { get; set; }
    }
}
