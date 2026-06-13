using System;

namespace Beanz.Models.Areas.HumanResourceManagement.Employees.Objects
{
    // Entity model generated from table structure
    public class EmployeeCalendar
    {
        public int EmployeeCalendarID { get; set; }
        public int PayrollPeriodID { get; set; }
        public string EmployeeCalendarCode { get; set; }
        public string EmployeeCalendarName { get; set; }
        public string EmployeeCalendarAlias { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public int TotalPresentDays { get; set; }
        public int TotalAbsentDays { get; set; }
        public int TotalLeaveDays { get; set; }
        public int TotalVacationDays { get; set; }
        public int TotalHolidays { get; set; }
        public int TotalWeekOffDays { get; set; }
        public int TotalLateDays { get; set; }
        public int TotalOverTimeDays { get; set; }
        public int TotalSingleEntryDays { get; set; }
        public int RequiredTotalMinutes { get; set; }
        public int AssignTotalMinutes { get; set; }
        public int OverTimeMinutes { get; set; }
        public int LateMinutes { get; set; }
        public int ExtraMinutes { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime PostedDate { get; set; }
        public int PostedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DeletedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPosted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
