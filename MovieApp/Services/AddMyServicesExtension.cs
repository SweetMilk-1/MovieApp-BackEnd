using MovieApp.Services.Security;

namespace MovieApp.Services
{
    public static class AddMyServicesExtension
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {

            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<ISessionService, SessionService>();

            return services;
        }
    }
}
