using System;

namespace Beanz.Models.Areas.HummanResourceManagement.Employees.Objects
{
    // Entity model generated from table structure
    public class EmployeeDependent
    {
        public int EmployeeDependentID { get; set; }
        public int RelationTypeID { get; set; }
        public int ResidenceIDTypeID { get; set; }
        public string EmployeeDependentCode { get; set; }
        public string EmployeeDependentName { get; set; }
        public string EmployeeDependentAlias { get; set; }
        public int EmployeeID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ResidenceIDNumber { get; set; }
        public bool IsDependent { get; set; }
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
