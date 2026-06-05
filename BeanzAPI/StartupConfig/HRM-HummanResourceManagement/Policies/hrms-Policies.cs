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
            services.AddScoped<IGosiPolicieRepository, GosiPolicieRepository>();
            services.AddScoped<IGosiPolicyDetailRepository, GosiPolicyDetailRepository>();
            services.AddScoped<IGosiPolicyEligibleRepository, GosiPolicyEligibleRepository>();
            services.AddScoped<IGosiPolicyPaymentRepository, GosiPolicyPaymentRepository>();
            services.AddScoped<IHolidayPolicieRepository, HolidayPolicieRepository>();
            services.AddScoped<IHolidayPolicyDayRepository, HolidayPolicyDayRepository>();
            services.AddScoped<IHolidayPolicyEligibleRepository, HolidayPolicyEligibleRepository>();
            services.AddScoped<IHolidayPolicyPaymentRepository, HolidayPolicyPaymentRepository>();
            services.AddScoped<IInsurancePolicieRepository, InsurancePolicieRepository>();
            services.AddScoped<IInsurancePolicyEligibleRepository, InsurancePolicyEligibleRepository>();
            services.AddScoped<ILeavePolicieRepository, LeavePolicieRepository>();
            services.AddScoped<ILeavePolicyEligibleRepository, LeavePolicyEligibleRepository>();
            services.AddScoped<ILeavePolicyPaymentRepository, LeavePolicyPaymentRepository>();
            services.AddScoped<ILoanPolicieRepository, LoanPolicieRepository>();
            services.AddScoped<ILoanPolicyEligibleRepository, LoanPolicyEligibleRepository>();
            services.AddScoped<ILoanPolicyPaymentRepository, LoanPolicyPaymentRepository>();
            services.AddScoped<IOverTimePolicieRepository, OverTimePolicieRepository>();
            services.AddScoped<IOverTimePolicyAllowanceRepository, OverTimePolicyAllowanceRepository>();
            services.AddScoped<IOvertimePolicyEligibleRepository, OvertimePolicyEligibleRepository>();
            services.AddScoped<IOvertimePolicyPaymentRepository, OvertimePolicyPaymentRepository>();
            services.AddScoped<IPaidTimeOffPolicieRepository, PaidTimeOffPolicieRepository>();
            services.AddScoped<IPaidTimeOffPolicyEligibleRepository, PaidTimeOffPolicyEligibleRepository>();
            services.AddScoped<IPaidTimeOffPolicyPaymentRepository, PaidTimeOffPolicyPaymentRepository>();
            services.AddScoped<IPayrollPolicieRepository, PayrollPolicieRepository>();
            services.AddScoped<IPayrollPolicyEligibleRepository, PayrollPolicyEligibleRepository>();
            services.AddScoped<IPayrollPolicyPaymentRepository, PayrollPolicyPaymentRepository>();
            services.AddScoped<IShiftPolicieRepository, ShiftPolicieRepository>();
            services.AddScoped<IShiftPolicyEligibleRepository, ShiftPolicyEligibleRepository>();
            services.AddScoped<ITicketPolicieRepository, TicketPolicieRepository>();
            services.AddScoped<ITicketPolicyEligibleRepository, TicketPolicyEligibleRepository>();
            services.AddScoped<ITicketPolicyPaymentRepository, TicketPolicyPaymentRepository>();
            services.AddScoped<ITrainingPolicieRepository, TrainingPolicieRepository>();
            services.AddScoped<ITrainingPolicyEligibleRepository, TrainingPolicyEligibleRepository>();
            services.AddScoped<IVacationPolicieRepository, VacationPolicieRepository>();
            services.AddScoped<IVacationPolicyEligibleRepository, VacationPolicyEligibleRepository>();
        }
    }
}
