using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Policies
{
    public class EndOfServicePolicieDTO
    {
        public int EndOfServicePolicieID { get; set; }
        public string EndOfServicePolicyCode { get; set; }
        public string EndOfServicePolicyName { get; set; }
        public string EndOfServicePolicyAlias { get; set; }
        public int NoticePeriodDays { get; set; }
        public bool IsEOSCalculateLastWorkingDate { get; set; }
        public bool IsSalaryCalculateLastWorkingDate { get; set; }
        public bool IsVacationCalculateLastWorkingDate { get; set; }
        public bool IsCancelComingVacation { get; set; }
        public bool IsCancelComingLeave { get; set; }
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

    public class EndOfServicePolicieViewModel
    {
        public List<EndOfServicePolicieDTO> EndOfServicePolicies { get; set; }
        public EndOfServicePolicieDTO EndOfServicePolicie { get; set; }
    }
}
