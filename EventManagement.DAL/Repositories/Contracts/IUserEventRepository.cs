using EventManagement.Model;

namespace EventManagement.DAL.Repositories.Contracts
{
    public interface IUserEventRepository : IGenericRepository<UserEvent>
    {
        Task<bool> UpdateCapacity(UserEvent model);
    }
}
