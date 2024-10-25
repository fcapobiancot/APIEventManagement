using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventManagement.DAL.Repositories.Contracts;
using EventManagement.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Azure.Core;

namespace EventManagement.DAL.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        // Principio de inyeccion de dependencia ( al crear la clase se le pasa el contexto evitando crear una instancia de la base de datos )
        private readonly EventManagementContext dbcontext;

        public GenericRepository(EventManagementContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<TModel> Get(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel model = await this.dbcontext.Set<TModel>().FirstOrDefaultAsync(filter);
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                this.dbcontext.Set<TModel>().Add(model);
                await this.dbcontext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(TModel model)
        {
            try
            {
                this.dbcontext.Set<TModel>().Update(model);
                await this.dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TModel model)
        {
            try
            {
                this.dbcontext.Set<TModel>().Remove(model);
                await this.dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IQueryable<TModel>> Consult(Expression<Func<TModel, bool>> filter = null)
        {
            try
            {
                IQueryable<TModel> queryModel = filter == null ? this.dbcontext.Set<TModel>() : this.dbcontext.Set<TModel>().Where(filter);
                return queryModel;
            }
            catch
            {
                throw;
            }
        }
    }
}
