using Beanz.Core.Areas.HumanResourceManagement.Transactions;
using Beanz.Data.Services.Areas.HumanResourceManagement.Transactions;

namespace Beanz.API.StartupConfig.HumanResourceManagement.Transactions
{
    public class hrms_Transactions
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ILeaveDayRepository, LeaveDayRepository>();
            services.AddScoped<ILeaveOpeningBalanceRepository, LeaveOpeningBalanceRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IPayrollPeriodRepository, PayrollPeriodRepository>();
        }
    }
}
