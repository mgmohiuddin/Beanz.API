using System;

namespace Beanz.Models.Areas.HummanResourceManagement.Policies.Objects
{
    // Entity model generated from table structure
    public class EndOfServicePolicySalaryAllowance
    {
        public int EndOfServicePolicySalaryAllowanceID { get; set; }
        public int EndOfServicePolicyID { get; set; }
        public int AllowanceTypeID { get; set; }
        public int AllowanceID { get; set; }
        public string EndOfServicePolicySalaryAllowanceCode { get; set; }
        public string EndOfServicePolicySalaryAllowanceName { get; set; }
        public string EndOfServicePolicySalaryAllowanceAlias { get; set; }
        public decimal Percentage { get; set; }
        public bool IsSalaryCalculateLastWorkingDate { get; set; }
        public bool IsPaidRecover { get; set; }
        public bool IsNoticePeriod { get; set; }
        public bool IsComingSalary { get; set; }
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
