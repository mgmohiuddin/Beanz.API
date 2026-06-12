using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Beanz.Business.Areas.HummanResourceManagement.Masters;

namespace Beanz.API.StartupConfig.HummanResourceManagement.Masters.Business
{
    public class hrms_Masters_Business
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAdvanceSalaryTypeBusiness, AdvanceSalaryTypeBusiness>();
            //services.AddScoped<IAllowanceBusiness, AllowanceBusiness>();
            //services.AddScoped<IAllowancesGroupBusiness, AllowancesGroupBusiness>();
            //services.AddScoped<IAllowanceTypeBusiness, AllowanceTypeBusiness>();
            //services.AddScoped<IAssetTypeBusiness, AssetTypeBusiness>();
            //services.AddScoped<IAttendanceTypeBusiness, AttendanceTypeBusiness>();
            //services.AddScoped<IBonusTypeBusiness, BonusTypeBusiness>();
            //services.AddScoped<IBusinessTripPayTypeBusiness, BusinessTripPayTypeBusiness>();
            //services.AddScoped<IBusinessTripTypeBusiness, BusinessTripTypeBusiness>();
            //services.AddScoped<IDesignationBusiness, DesignationBusiness>();
            //services.AddScoped<IDocumentSubmissionTypeBusiness, DocumentSubmissionTypeBusiness>();
            //services.AddScoped<IDocumentTypeBusiness, DocumentTypeBusiness>();
            //services.AddScoped<IEducationTypeBusiness, EducationTypeBusiness>();
            //services.AddScoped<IEndOfServiceTypeBusiness, EndOfServiceTypeBusiness>();
            //services.AddScoped<IGosiTypeBusiness, GosiTypeBusiness>();
            //services.AddScoped<IGradeBusiness, GradeBusiness>();
            //services.AddScoped<IHolidayTypeBusiness, HolidayTypeBusiness>();
            //services.AddScoped<IInsuranceTypeBusiness, InsuranceTypeBusiness>();
            //services.AddScoped<ILeaveTypeBusiness, LeaveTypeBusiness>();
            //services.AddScoped<ILoanTypeBusiness, LoanTypeBusiness>();
            //services.AddScoped<IOvertimeTypeBusiness, OvertimeTypeBusiness>();
            //services.AddScoped<IPaidTimeOffTypeBusiness, PaidTimeOffTypeBusiness>();
            //services.AddScoped<IPayrollTypeBusiness, PayrollTypeBusiness>();
            //services.AddScoped<IPermitTypeBusiness, PermitTypeBusiness>();
            //services.AddScoped<IPositionBusiness, PositionBusiness>();
            //services.AddScoped<IRelationTypeBusiness, RelationTypeBusiness>();
            //services.AddScoped<IResidenceIDTypeBusiness, ResidenceIDTypeBusiness>();
            //services.AddScoped<IShiftTypeBusiness, ShiftTypeBusiness>();
            //services.AddScoped<ISponsorBusiness, SponsorBusiness>();
            //services.AddScoped<ISubGradeBusiness, SubGradeBusiness>();
            //services.AddScoped<ITicketClassTypeBusiness, TicketClassTypeBusiness>();
            //services.AddScoped<ITicketTypeBusiness, TicketTypeBusiness>();
            //services.AddScoped<ITrainingTypeBusiness, TrainingTypeBusiness>();
            //services.AddScoped<ITravelTypeBusiness, TravelTypeBusiness>();
            //services.AddScoped<IVacationTypeBusiness, VacationTypeBusiness>();
            //services.AddScoped<IVisaTypeBusiness, VisaTypeBusiness>();
            //services.AddScoped<IWeekDayBusiness, WeekDayBusiness>();
            //services.AddScoped<IWorkProfessionBusiness, WorkProfessionBusiness>();
        }
    }
}
