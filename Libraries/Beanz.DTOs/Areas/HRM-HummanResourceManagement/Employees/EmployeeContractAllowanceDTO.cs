using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Employees
{
    public class EmployeeContractAllowanceDTO
    {
        public int EmployeeContractAllowanceID { get; set; }
        public int EmployeeContractID { get; set; }
        public int AllowanceID { get; set; }
        public int AllowanceTypeID { get; set; }
        public string EmployeeContractAllowanceCode { get; set; }
        public string EmployeeContractAllowanceName { get; set; }
        public string EmployeeContractAllowanceAlias { get; set; }
        public int EmployeeID { get; set; }
        public DateTime EffectDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Amount { get; set; }
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

    public class EmployeeContractAllowanceViewModel
    {
        public List<EmployeeContractAllowanceDTO> EmployeeContractAllowances { get; set; }
        public EmployeeContractAllowanceDTO EmployeeContractAllowance { get; set; }
    }
}
