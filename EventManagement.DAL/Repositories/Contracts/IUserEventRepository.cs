using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventManagement.Model;

namespace EventManagement.DAL.Repositories.Contracts
{
    public interface IUserEventRepository : IGenericRepository<UserEvent>
    {
        Task<bool> UpdateCapacity(UserEvent model);
    }
}
