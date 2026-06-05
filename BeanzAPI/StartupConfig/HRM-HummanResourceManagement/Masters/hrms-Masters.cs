using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.Data.Services.Areas.HummanResourceManagement.Masters;

namespace Beanz.API.StartupConfig.HRM_HummanResourceManagement.Masters
{
    public class hrms_Masters
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAdvanceSalaryTypeRepository, AdvanceSalaryTypeRepository>();  
            services.AddScoped<IAllowanceTypeRepository, AllowanceTypeRepository>();
            services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
            services.AddScoped<IAttendanceTypeRepository, AttendanceTypeRepository>();
            services.AddScoped<IBonusTypeRepository, BonusTypeRepository>();
            services.AddScoped<IBusinessTripPayTypeRepository, BusinessTripPayTypeRepository>();
        }
    }
}
