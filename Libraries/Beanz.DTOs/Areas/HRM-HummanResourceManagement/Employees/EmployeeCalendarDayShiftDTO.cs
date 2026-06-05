using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Employees
{
    public class EmployeeCalendarDayShiftDTO
    {
        public int EmployeeCalendarDayShiftID { get; set; }
        public int EmployeeCalendarID { get; set; }
        public int EmployeeCalendarDayID { get; set; }
        public string EmployeeCalendarDayShiftCode { get; set; }
        public string EmployeeCalendarDayShiftName { get; set; }
        public string EmployeeCalendarDayShiftAlias { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftNumber { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }
        public DateTime ShiftMinutes { get; set; }
        public DateTime INTime { get; set; }
        public DateTime OUTTime { get; set; }
        public int WorkMinutes { get; set; }
        public bool IsShiftEndNextDay { get; set; }
        public bool IsAbsent { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsLeave { get; set; }
        public bool IsVacation { get; set; }
        public bool IsOverTime { get; set; }
        public bool IsWeekOff { get; set; }
        public bool IsExcuse { get; set; }
        public bool IsLate { get; set; }
        public bool IsSingleEntry { get; set; }
        public bool IsAdjustLate { get; set; }
        public bool IsAdjustAbsent { get; set; }
        public bool IsAdjustSingleEntry { get; set; }
        public int ExtraBeforeIN { get; set; }
        public int ExtraAfterOUT { get; set; }
        public int ExtratTotalMinutes { get; set; }
        public int LateMinutesIN { get; set; }
        public int LateMinutesOUT { get; set; }
        public int LateMinutesTotal { get; set; }
        public DateTime ExcuseStartTime { get; set; }
        public DateTime ExcuseEndTime { get; set; }
        public int ExcuseMinutes { get; set; }
        public DateTime AdjustINTime { get; set; }
        public DateTime AdjustOUTTime { get; set; }
        public int AdjustMinutes { get; set; }
        public int ShiftINToleranceMin { get; set; }
        public int ShiftOUTToleranceMin { get; set; }
        public DateTime FlexibleShiftStartTimeEarly { get; set; }
        public DateTime FlexibleShiftStartTimeLate { get; set; }
        public DateTime FlexibleShiftEndTimeEarly { get; set; }
        public DateTime FlexibleShiftEndTimeLate { get; set; }
        public DateTime FinalIN { get; set; }
        public DateTime FinalOUT { get; set; }
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

    public class EmployeeCalendarDayShiftViewModel
    {
        public List<EmployeeCalendarDayShiftDTO> EmployeeCalendarDayShifts { get; set; }
        public EmployeeCalendarDayShiftDTO EmployeeCalendarDayShift { get; set; }
    }
}
