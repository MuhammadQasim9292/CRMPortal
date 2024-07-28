// CustomServices.cs
using Application;
using Application.Interfaces;
using Domain.Models.Entities;
using Infrastructure;
using Infrastructure.Services;



namespace Jwt_With_CleanArchitecture.InjectServices
{
    public static class CustomServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IType, TypeService>();
            //services.AddScoped<ITypeValue, TypeValueService>();
            services.AddScoped<IUser,UserService>();
            services.AddScoped<IRole,RoleService>();
            services.AddScoped<ISearch, SearchService>();

        }
    }
}
