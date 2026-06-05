using System;

namespace Beanz.Models.Areas.HummanResourceManagement.Employees.Objects
{
    // Entity model generated from table structure
    public class EmployeeCalendarDay
    {
        public int EmployeeCalendarDayID { get; set; }
        public int EmployeeCalendarID { get; set; }
        public string EmployeeCalendarDayCode { get; set; }
        public string EmployeeCalendarDayName { get; set; }
        public string EmployeeCalendarDayAlias { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalMinutes { get; set; }
        public bool IsAbsent { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsLeave { get; set; }
        public bool IsVacation { get; set; }
        public bool IsOverTime { get; set; }
        public bool IsWeekOff { get; set; }
        public bool IsExcuse { get; set; }
        public bool IsLate { get; set; }
        public bool IsSingleEntry { get; set; }
        public int ExtratTotalBeforeAfterMinutes { get; set; }
        public int ExtraTotalShiftsMinutes { get; set; }
        public int ExcuseMinutes { get; set; }
        public int LateMinutes { get; set; }
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
