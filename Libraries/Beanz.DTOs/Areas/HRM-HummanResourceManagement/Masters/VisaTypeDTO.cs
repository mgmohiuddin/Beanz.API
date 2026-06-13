using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Masters
{
    public class VisaTypeDTO
    {
        public int VisaTypeID { get; set; }
        public string VisaTypeCode { get; set; }
        public string VisaTypeName { get; set; }
        public string VisaTypeAlias { get; set; }
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

    public class VisaTypeViewModel
    {
        public List<VisaTypeDTO> VisaTypes { get; set; }
        public VisaTypeDTO VisaType { get; set; }
    }
}
