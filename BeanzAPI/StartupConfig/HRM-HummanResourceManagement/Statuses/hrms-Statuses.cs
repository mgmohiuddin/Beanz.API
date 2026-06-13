using Beanz.Core.Areas.HumanResourceManagement.Statuses;
using Beanz.Data.Services.Areas.HumanResourceManagement.Statuses;

namespace Beanz.API.StartupConfig.HumanResourceManagement.Statuses
{
    public class hrms_Statuses
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEmployeeContractStatuseRepository, EmployeeContractStatuseRepository>();
        }
    }
}
