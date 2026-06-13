using Beanz.Core.Areas.FinancialAccountingSystem.Accounts;
using Beanz.Data.Services.Areas.FinancialAccountingSystem.Accounts;

namespace Beanz.API.StartupConfig.FinancialAccountingSystem.Accounts
{
    public class fas_Accounts
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IChartOfAccountRepository, ChartOfAccountRepository>();
        }
    }
}
