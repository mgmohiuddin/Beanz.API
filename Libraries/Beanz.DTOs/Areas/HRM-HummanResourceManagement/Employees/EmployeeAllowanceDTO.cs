using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Employees
{
    public class EmployeeAllowanceDTO
    {
        public int EmployeeAllowanceID { get; set; }
        public int AllowanceID { get; set; }
        public int AllowanceTypeID { get; set; }
        public string EmployeeAllowanceCode { get; set; }
        public string EmployeeAllowanceName { get; set; }
        public string EmployeeAllowanceAlias { get; set; }
        public int EmployeeID { get; set; }
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

    public class EmployeeAllowanceViewModel
    {
        public List<EmployeeAllowanceDTO> EmployeeAllowances { get; set; }
        public EmployeeAllowanceDTO EmployeeAllowance { get; set; }
    }
}
