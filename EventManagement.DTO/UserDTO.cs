using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? ProfilePic { get; set; }

        public string? Socials { get; set; }

        public int RoleId { get; set; }

        public string? RolName { get; set; }
    }
}
