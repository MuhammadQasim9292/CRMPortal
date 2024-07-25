using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt_With_CleanArchitecture.InjectServices
{
    public static class DistrictCustomServices
    {
        public static void AddDistrictServices(this IServiceCollection services)
        {
            services.AddScoped<IDistrictService, DistrictService>();
        }
    }
}
