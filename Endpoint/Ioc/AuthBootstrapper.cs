using Microsoft.AspNetCore.Authentication.Cookies;
namespace Endpoint.Ioc
{
    public static class AuthBootstrapper
    {
        public static IServiceCollection AuthConfigure(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(SD.AdminManager, policy => policy.RequireRole(SD.AdminManager));
            });
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Auth/Login");
                options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
                options.ExpireTimeSpan = TimeSpan.FromDays(7.0);
            });
            return services;
        }
    }
}