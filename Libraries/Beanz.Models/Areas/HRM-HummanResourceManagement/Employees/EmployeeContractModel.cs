using System;

namespace Beanz.Models.Areas.HummanResourceManagement.Employees.Objects
{
    // Entity model generated from table structure
    public class EmployeeContract
    {
        public int EmployeeContractID { get; set; }
        public int EmployeeContractStatusID { get; set; }
        public string EmployeeContractCode { get; set; }
        public string EmployeeContractName { get; set; }
        public string EmployeeContractAlias { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ContractFromDate { get; set; }
        public DateTime ContractToDate { get; set; }
        public DateTime JoiningDate { get; set; }
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
