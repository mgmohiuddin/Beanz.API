using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.Data.Services.Areas.HummanResourceManagement.Policies;

namespace Beanz.API.StartupConfig.HRM_HummanResourceManagement.Policies
{
    public class hrms_Policies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAdvanceSalaryPolicieRepository, AdvanceSalaryPolicieRepository>();
            services.AddScoped<IAdvanceSalaryPolicyPaymentRepository, AdvanceSalaryPolicyPaymentRepository>();
            services.AddScoped<IAllowancePolicieRepository, AllowancePolicieRepository>();
            services.AddScoped<IAllowancePolicyDetailRepository, AllowancePolicyDetailRepository>();
            services.AddScoped<IAllowancePolicyPaymentRepository, AllowancePolicyPaymentRepository>();
            services.AddScoped<IAttendancePolicieRepository, AttendancePolicieRepository>();
        }
    }
}
