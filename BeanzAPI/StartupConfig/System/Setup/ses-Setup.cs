using Beanz.Core.Areas.System.Setup;
using Beanz.Data.Services.Areas.System.Setup;

namespace Beanz.API.StartupConfig.System.Setup
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
