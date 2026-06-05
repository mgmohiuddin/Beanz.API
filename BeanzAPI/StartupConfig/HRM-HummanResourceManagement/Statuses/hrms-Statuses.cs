using Beanz.Core.Areas.HummanResourceManagement.Statuses;
using Beanz.Data.Services.Areas.HummanResourceManagement.Statuses;

namespace Beanz.API.StartupConfig.HummanResourceManagement.Statuses
{
    public class hrms_Statuses
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEmployeeContractStatuseRepository, EmployeeContractStatuseRepository>();
        }
    }
}
