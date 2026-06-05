using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.System.Setup
{
    public class SystemScreenDTO
    {
        public int SystemScreenID { get; set; }
        public int SystemModuleID { get; set; }
        public string SystemScreenCode { get; set; }
        public string SystemScreenName { get; set; }
        public string SystemScreenAlias { get; set; }
        public string Area { get; set; }
        public string AreaSubFolder { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IconTag { get; set; }
        public string ScreenURL { get; set; }
        public bool IsCodeScreen { get; set; }
        public string SchemaCode { get; set; }
        public string ScreenTableName { get; set; }
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

    public class SystemScreenViewModel
    {
        public List<SystemScreenDTO> SystemScreens { get; set; }
        public SystemScreenDTO SystemScreen { get; set; }
    }
}
