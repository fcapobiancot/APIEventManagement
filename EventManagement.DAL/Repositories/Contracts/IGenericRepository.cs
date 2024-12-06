using System.Linq.Expressions;
namespace EventManagement.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> Get(Expression<Func<TModel, bool>> filter);
        Task<TModel> Create(TModel model);
        Task<bool> Update(TModel model);
        Task<bool> Delete(TModel model);
        Task<IQueryable<TModel>> Consult(Expression<Func<TModel, bool>> filter = null);
    }
}
