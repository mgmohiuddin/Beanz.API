using Beanz.Core.Areas.HummanResourceManagement.Transactions;
using Beanz.Data.Services.Areas.HummanResourceManagement.Transactions;

namespace Beanz.API.StartupConfig.HummanResourceManagement.Transactions
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
