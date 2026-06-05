using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.Data.Services.Areas.FinancialAccountingSystem.Masters;

namespace Beanz.API.StartupConfig.FinancialAccountingSystem.Masters
{
    public class fas_Masters
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITaxTypeRepository, TaxTypeRepository>();
        }
    }
}
