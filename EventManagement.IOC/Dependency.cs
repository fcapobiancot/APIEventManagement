using EventManagement.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventManagement.DAL.Repositories.Contracts;
using EventManagement.DAL.Repositories;
using EventManagement.Utility;
using EventManagement.BLL.Services;
using EventManagement.BLL.Services.Contracts;


namespace EventManagement.IOC
{
    public static class Dependency
    {
        public static void DependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventManagementContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLstring"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserEventRepository, UserEventRepository>();

            // inyectando automapper de model a DTO y viceversa
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IEventService, EventService>();
 

        }


    }
}
