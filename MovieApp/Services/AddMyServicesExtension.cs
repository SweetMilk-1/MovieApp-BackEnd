using MovieApp.Services.Security;
using MovieApp.Services.User;

namespace MovieApp.Services
{
    public static class AddMyServicesExtension
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {

            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IUserInfoService, UserInfoService>();

            return services;
        }
    }
}
