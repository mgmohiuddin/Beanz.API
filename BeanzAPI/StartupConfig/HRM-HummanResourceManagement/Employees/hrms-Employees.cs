using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.Data.Services.Areas.HummanResourceManagement.Employees;

namespace Beanz.API.StartupConfig.HummanResourceManagement.Employees
{
    public class hrms_Employees
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
