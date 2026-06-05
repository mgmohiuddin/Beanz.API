using System;

namespace Beanz.Models.Areas.HummanResourceManagement.Masters.Objects
{
    // Entity model generated from table structure
    public class Allowance
    {
        public int AllowanceID { get; set; }
        public int AllowancesGroupID { get; set; }
        public int AllowanceTypeID { get; set; }
        public string AllowanceCode { get; set; }
        public string AllowanceName { get; set; }
        public string AllowanceAlias { get; set; }
        public bool IsRequiredPolicy { get; set; }
        public bool IsUnstructured { get; set; }
        public bool IsBasicSalary { get; set; }
        public bool IsFixedAllowance { get; set; }
        public bool IsLinkedPolicy { get; set; }
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
