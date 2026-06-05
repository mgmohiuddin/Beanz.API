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
            services.AddScoped<IAttendancePolicyEligibleRepository, AttendancePolicyEligibleRepository>();
            services.AddScoped<IAttendancePolicyPaymentRepository, AttendancePolicyPaymentRepository>();
            services.AddScoped<IBonusPolicieRepository, BonusPolicieRepository>();
            services.AddScoped<IBonusPolicyEligibleRepository, BonusPolicyEligibleRepository>();
            services.AddScoped<IBonusPolicyPaymentRepository, BonusPolicyPaymentRepository>();
            services.AddScoped<IBusinessTripPolicieRepository, BusinessTripPolicieRepository>();
            services.AddScoped<IBusinessTripPolicyEligibleRepository, BusinessTripPolicyEligibleRepository>();
            services.AddScoped<IBusinessTripPolicyPaymentRepository, BusinessTripPolicyPaymentRepository>();
            services.AddScoped<IEndOfServicePolicieRepository, EndOfServicePolicieRepository>();
            services.AddScoped<IEndOfServicePolicyAllowanceRepository, EndOfServicePolicyAllowanceRepository>();
            services.AddScoped<IEndOfServicePolicyCalculationRepository, EndOfServicePolicyCalculationRepository>();
            services.AddScoped<IEndOfServicePolicySalaryAllowanceRepository, EndOfServicePolicySalaryAllowanceRepository>();
            services.AddScoped<IEndOfServicePolicyYearSalarieRepository, EndOfServicePolicyYearSalarieRepository>();
        }
    }
}
