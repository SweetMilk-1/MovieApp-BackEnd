using MovieApp.Services.User;

namespace MovieApp.Services
{
    public static class ServiceRigisterExtension
    {
        public static IServiceCollection AddBussinesServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();


            return services;
        }
    }
}
