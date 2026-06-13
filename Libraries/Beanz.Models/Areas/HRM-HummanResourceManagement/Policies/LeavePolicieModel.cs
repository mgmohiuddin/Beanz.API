using System;

namespace Beanz.Models.Areas.HumanResourceManagement.Policies.Objects
{
    // Entity model generated from table structure
    public class LeavePolicie
    {
        public int LeavePolicieID { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeavePolicyCode { get; set; }
        public string LeavePolicyName { get; set; }
        public string LeavePolicyAlias { get; set; }
        public int MinDays { get; set; }
        public int MaxDays { get; set; }
        public bool IsWeekOffInclude { get; set; }
        public bool IsHoldidaysInclude { get; set; }
        public int MaxAllowTimes { get; set; }
        public int IntervalMonths { get; set; }
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
