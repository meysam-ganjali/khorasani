
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
            services.AddScoped<ISliderService,SliderService>();
            services.AddScoped<ICompetitivedvantagesService,CompetitivedvantagesService>();
            services.AddScoped<ISettingService,SettingService>();
            services.AddScoped<ICompletedProject,CompletedProject>();
            services.AddScoped<IAuthService,AuthService>();
            return services;
         }
    }
}