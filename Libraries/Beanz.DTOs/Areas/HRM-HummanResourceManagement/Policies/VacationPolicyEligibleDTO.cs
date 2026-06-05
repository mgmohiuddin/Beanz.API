using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Policies
{
    public class VacationPolicyEligibleDTO
    {
        public int VacationPolicyEligibleID { get; set; }
        public string VacationPolicyEligibleCode { get; set; }
        public string VacationPolicyEligibleName { get; set; }
        public string VacationPolicyEligibleAlias { get; set; }
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

    public class VacationPolicyEligibleViewModel
    {
        public List<VacationPolicyEligibleDTO> VacationPolicyEligibles { get; set; }
        public VacationPolicyEligibleDTO VacationPolicyEligible { get; set; }
    }
}
