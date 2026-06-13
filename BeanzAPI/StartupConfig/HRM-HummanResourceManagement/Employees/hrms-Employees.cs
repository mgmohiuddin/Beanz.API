using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.Data.Services.Areas.HumanResourceManagement.Employees;

namespace Beanz.API.StartupConfig.HumanResourceManagement.Employees
{
    public class hrms_Employees
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEmployeeAllowanceRepository, EmployeeAllowanceRepository>();
            services.AddScoped<IEmployeeAssignPolicieRepository, EmployeeAssignPolicieRepository>();
            services.AddScoped<IEmployeeCalendarDayRepository, EmployeeCalendarDayRepository>();
            services.AddScoped<IEmployeeCalendarDayShiftRepository, EmployeeCalendarDayShiftRepository>();
            services.AddScoped<IEmployeeCalendarRepository, EmployeeCalendarRepository>();
            services.AddScoped<IEmployeeContactInformationRepository, EmployeeContactInformationRepository>();
            services.AddScoped<IEmployeeContractAllowanceRepository, EmployeeContractAllowanceRepository>();
            services.AddScoped<IEmployeeContractOfficialInformationRepository, EmployeeContractOfficialInformationRepository>();
            services.AddScoped<IEmployeeContractRepository, EmployeeContractRepository>();
            services.AddScoped<IEmployeeDependentDocumentRepository, EmployeeDependentDocumentRepository>();
            services.AddScoped<IEmployeeDependentRepository, EmployeeDependentRepository>();
            services.AddScoped<IEmployeeDocumentRepository, EmployeeDocumentRepository>();
            services.AddScoped<IEmployeeFinancialInformationRepository, EmployeeFinancialInformationRepository>();
            services.AddScoped<IEmployeeLanguageRepository, EmployeeLanguageRepository>();
            services.AddScoped<IEmployeeOfficialInformationRepository, EmployeeOfficialInformationRepository>();
            services.AddScoped<IEmployeeQualificationRepository, EmployeeQualificationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
