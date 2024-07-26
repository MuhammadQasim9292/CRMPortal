using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt_With_CleanArchitecture.InjectServices
{
    public static class CustomServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // Register DepartmentService
           // services.AddScoped<IDepartmentService, DepartmentService>();

            // Register EmployeeService
            //services.AddScoped<IEmployeeService, EmployeeService>();
           // services.AddScoped<IEmployeeJobDescriptionService, EmployeeService>();
            services.AddScoped<IEmployeeJobDescriptionService, EmployeeService> ();

        }
    }
}
