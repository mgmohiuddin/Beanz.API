using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Policies
{
    public class EndOfServicePolicyYearSalarieDTO
    {
        public int EndOfServicePolicyYearSalarieID { get; set; }
        public string EndOfServicePolicyYearSalaryCode { get; set; }
        public string EndOfServicePolicyYearSalaryName { get; set; }
        public string EndOfServicePolicyYearSalaryAlias { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
        public decimal SalaryPerYear { get; set; }
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

    public class EndOfServicePolicyYearSalarieViewModel
    {
        public List<EndOfServicePolicyYearSalarieDTO> EndOfServicePolicyYearSalaries { get; set; }
        public EndOfServicePolicyYearSalarieDTO EndOfServicePolicyYearSalarie { get; set; }
    }
}
