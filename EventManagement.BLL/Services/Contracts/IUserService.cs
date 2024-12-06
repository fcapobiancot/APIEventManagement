using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventManagement.Model;
using EventManagement.DTO;
using System.Globalization;

namespace EventManagement.BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<List<UserDTO>> ListUsers();
        Task<SessionDTO> validateCredentials(string email, string passoword);
        Task<UserDTO> CreateUser(UserDTO model);
        Task<bool> UpdateUser(UserDTO model);
        Task<bool> DeleteUser(int id);
        
    }
}
