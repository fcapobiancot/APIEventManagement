using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventManagement.DAL.Repositories.Contracts;
using EventManagement.DAL.DBContext;
using EventManagement.Model;

namespace EventManagement.DAL.Repositories
{
    public class UserEventRepository : GenericRepository<UserEvent>, IUserEventRepository
    {
        private readonly EventManagementContext dbcontext;

        public UserEventRepository(EventManagementContext dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<bool> UpdateCapacity(UserEvent model)
        {
            using (var transaction = this.dbcontext.Database.BeginTransaction())
            {
                Event @event = model.Event;

                try
                {
                    @event.Capacity = @event.Capacity - 1;
                    this.dbcontext.Update(@event);
                    await this.dbcontext.SaveChangesAsync();

                    transaction.Commit();

                }
                catch
                {

                    transaction.Rollback();
                }

                return true;
            }
 



        }
    }
}
