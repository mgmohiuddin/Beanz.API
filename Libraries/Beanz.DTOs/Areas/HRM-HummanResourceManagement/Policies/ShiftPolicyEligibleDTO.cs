using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Policies
{
    public class ShiftPolicyEligibleDTO
    {
        public int ShiftPolicyEligibleID { get; set; }
        public string ShiftPolicyEligibleCode { get; set; }
        public string ShiftPolicyEligibleName { get; set; }
        public string ShiftPolicyEligibleAlias { get; set; }
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

    public class ShiftPolicyEligibleViewModel
    {
        public List<ShiftPolicyEligibleDTO> ShiftPolicyEligibles { get; set; }
        public ShiftPolicyEligibleDTO ShiftPolicyEligible { get; set; }
    }
}
