using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Policies
{
    public class BusinessTripPolicieDTO
    {
        public int BusinessTripPolicieID { get; set; }
        public int BusinessTripTypeID { get; set; }
        public string BusinessTripPolicyCode { get; set; }
        public string BusinessTripPolicyName { get; set; }
        public string BusinessTripPolicyAlias { get; set; }
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

    public class BusinessTripPolicieViewModel
    {
        public List<BusinessTripPolicieDTO> BusinessTripPolicies { get; set; }
        public BusinessTripPolicieDTO BusinessTripPolicie { get; set; }
    }
}
