using Beanz.Core.Areas.BeanzSystem.Setup;
using Beanz.Data.Services.Areas.BeanzSystem.Setup;

namespace Beanz.API.StartupConfig.BeanzSystem.Setup
{
    public class ses_Setup
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ISystemModuleRepository, SystemModuleRepository>();
            services.AddScoped<ISystemScreenEndpointRepository, SystemScreenEndpointRepository>();
            services.AddScoped<ISystemScreenRepository, SystemScreenRepository>();

        }
    }
}
