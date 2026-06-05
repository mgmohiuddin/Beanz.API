using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.Data.Services.Areas.HummanResourceManagement.Masters;

namespace Beanz.API.StartupConfig.HRM_HummanResourceManagement.Masters
{
    public class HRM_Masters
    {
        public static void Register(IServiceCollection services)
        {             
            services.AddScoped<IAllowanceRepository, AllowanceRepository>(); 
        }
    }
}
