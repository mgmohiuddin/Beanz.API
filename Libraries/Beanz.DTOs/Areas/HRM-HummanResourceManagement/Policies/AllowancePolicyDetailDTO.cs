using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Policies
{
    public class AllowancePolicyDetailDTO
    {
        public int AllowancePolicyDetailID { get; set; }
        public int AllowancePolicyID { get; set; }
        public string AllowancePolicyDetailCode { get; set; }
        public string AllowancePolicyDetailName { get; set; }
        public string AllowancePolicyDetailAlias { get; set; }
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

    public class AllowancePolicyDetailViewModel
    {
        public List<AllowancePolicyDetailDTO> AllowancePolicyDetails { get; set; }
        public AllowancePolicyDetailDTO AllowancePolicyDetail { get; set; }
    }
}
