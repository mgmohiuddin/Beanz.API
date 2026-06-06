using Beanz.Business.Areas.HummanResourceManagement.Masters;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.Data.Services.Areas.HummanResourceManagement.Masters;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;

namespace Beanz.API.StartupConfig.HummanResourceManagement.Masters
{
    public class hrms_Masters
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAdvanceSalaryTypeRepository, AdvanceSalaryTypeRepository>();
            services.AddScoped<IAllowanceRepository, AllowanceRepository>();
            services.AddScoped<IAllowancesGroupRepository, AllowancesGroupRepository>();
            services.AddScoped<IAllowanceTypeRepository, AllowanceTypeRepository>();
            services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
            services.AddScoped<IAttendanceTypeRepository, AttendanceTypeRepository>();
            services.AddScoped<IBonusTypeRepository, BonusTypeRepository>();
            services.AddScoped<IBusinessTripPayTypeRepository, BusinessTripPayTypeRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IDocumentSubmissionTypeRepository, DocumentSubmissionTypeRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IEducationTypeRepository, EducationTypeRepository>();
            services.AddScoped<IEndOfServiceTypeRepository, EndOfServiceTypeRepository>();
            services.AddScoped<IGosiTypeRepository, GosiTypeRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IHolidayTypeRepository, HolidayTypeRepository>();
            services.AddScoped<IInsuranceTypeRepository, InsuranceTypeRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILoanTypeRepository, LoanTypeRepository>();
            services.AddScoped<IOvertimeTypeRepository, OvertimeTypeRepository>();
            services.AddScoped<IPaidTimeOffTypeRepository, PaidTimeOffTypeRepository>();
            services.AddScoped<IPayrollTypeRepository, PayrollTypeRepository>();
            services.AddScoped<IPermitTypeRepository, PermitTypeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IRelationTypeRepository, RelationTypeRepository>();
            services.AddScoped<IResidenceIDTypeRepository, ResidenceIDTypeRepository>();
            services.AddScoped<IShiftTypeRepository, ShiftTypeRepository>();
            services.AddScoped<ISponsorRepository, SponsorRepository>();
            services.AddScoped<ISubGradeRepository, SubGradeRepository>();
            services.AddScoped<ITicketClassTypeRepository, TicketClassTypeRepository>();
            services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            services.AddScoped<ITrainingTypeRepository, TrainingTypeRepository>();
            services.AddScoped<ITravelTypeRepository, TravelTypeRepository>();
            services.AddScoped<IVacationTypeRepository, VacationTypeRepository>();
            services.AddScoped<IVisaTypeRepository, VisaTypeRepository>();
            services.AddScoped<IWeekDayRepository, WeekDayRepository>();
            services.AddScoped<IWorkProfessionRepository, WorkProfessionRepository>();
            services.AddScoped<IAllowanceBusiness, AllowanceBusiness>();
        }
    }
}
