using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using services.Contracts;
using services.Impeliment;

namespace Endpoint.Ioc
{
    public static class ServiceBootstraper
    {
         public static IServiceCollection registerService(this IServiceCollection services){

            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<ICategoryService,CategoryServie>();
            services.AddScoped<IProductService,ProductService>();
            return services;
         }
    }
}