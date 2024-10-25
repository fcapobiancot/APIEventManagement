using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventManagement.BLL.Services.Contracts;
using EventManagement.DAL.Repositories.Contracts;
using EventManagement.Model;


namespace EventManagement.BLL.Services
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> rolRepository;

        public RolService(IGenericRepository<Rol> rolRepository)
        {
            this.rolRepository = rolRepository;
        }

        public async Task<List<Rol>> List()
        {
            try
            {
                var rolList = await this.rolRepository.Consult();
                return rolList.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
