using System;

namespace Beanz.Models.Areas.HummanResourceManagement.Policies.Objects
{
    // Entity model generated from table structure
    public class LoanPolicie
    {
        public int LoanPolicieID { get; set; }
        public int LoanTypeID { get; set; }
        public string LoanPolicyCode { get; set; }
        public string LoanPolicyName { get; set; }
        public string LoanPolicyAlias { get; set; }
        public int MinLoan { get; set; }
        public int MaxLoan { get; set; }
        public int NoOfEMIs { get; set; }
        public int MaxNoOfEMIs { get; set; }
        public int MinWorkYears { get; set; }
        public int MaxDeductionPercentage { get; set; }
        public bool IsValueFromEOS { get; set; }
        public bool IsAllowEMIReshedule { get; set; }
        public bool IsGuarentorRequired { get; set; }
        public int LoanIntervalDays { get; set; }
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
