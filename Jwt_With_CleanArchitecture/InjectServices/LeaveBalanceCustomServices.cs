using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt_With_CleanArchitecture.InjectServices
{
    public static class LeaveBalanceCustomServices
    {
        public static void AddLeaveBalanceServices(this IServiceCollection services)
        {
            services.AddScoped<ILeaveBalanceService, LeaveBalanceService>();
        }
    }
}
