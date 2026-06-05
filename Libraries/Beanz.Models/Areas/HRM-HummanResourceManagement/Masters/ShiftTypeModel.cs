using System;

namespace Beanz.Models.Areas.HummanResourceManagement.Masters.Objects
{
    // Entity model generated from table structure
    public class ShiftType
    {
        public int ShiftTypeID { get; set; }
        public string ShiftTypeCode { get; set; }
        public string ShiftTypeName { get; set; }
        public string ShiftTypeAlias { get; set; }
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
