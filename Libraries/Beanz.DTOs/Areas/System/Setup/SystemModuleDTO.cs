using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.System.Setup
{
    public class SystemModuleDTO
    {
        public int SystemModuleID { get; set; }
        public string SystemModuleCode { get; set; }
        public string SystemModuleName { get; set; }
        public string SystemModuleAlias { get; set; }
        public string IconTag { get; set; }
        public string ParentSystemModuleCode { get; set; }
        public int ParentSystemModuleID { get; set; }
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

    public class SystemModuleViewModel
    {
        public List<SystemModuleDTO> SystemModules { get; set; }
        public SystemModuleDTO SystemModule { get; set; }
    }
}
