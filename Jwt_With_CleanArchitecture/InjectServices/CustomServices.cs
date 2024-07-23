using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt_With_CleanArchitecture.InjectServices
{
    public static class CustomServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
        }
    }
}
