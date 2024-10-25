using EventManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BLL.Services.Contracts
{
    public interface IRolService
    {
        Task<List<Rol>> List(); 
    }
}
