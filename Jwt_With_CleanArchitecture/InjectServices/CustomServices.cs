// CustomServices.cs
using Application;
using Application.Interfaces;
using Infrastructure;
using Infrastructure.Services;


namespace Jwt_With_CleanArchitecture.InjectServices
{
    public static class CustomServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IBook, BookService>();
            services.AddScoped<IUser, UserService>();
          
        }
    }
}
