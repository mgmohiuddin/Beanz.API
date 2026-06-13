using Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts;
using Beanz.Business.Areas.FinancialAccountingSystem.Accounts;

namespace Beanz.API.StartupConfig.FinancialAccountingSystem.Accounts.Business
{
    public class fas_Accounts_Business
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAccountTypeBusiness, AccountTypeBusiness>();
            services.AddScoped<IChartOfAccountBusiness, ChartOfAccountBusiness>();
        }
    }
}
