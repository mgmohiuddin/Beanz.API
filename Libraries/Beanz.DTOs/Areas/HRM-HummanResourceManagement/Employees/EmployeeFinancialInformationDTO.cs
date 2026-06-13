using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Employees
{
    public class EmployeeFinancialInformationDTO
    {
        public int EmployeeFinancialInformationID { get; set; }
        public int BankID { get; set; }
        public int BankAccountTypeID { get; set; }
        public string EmployeeFinancialInformationCode { get; set; }
        public string EmployeeFinancialInformationName { get; set; }
        public string EmployeeFinancialInformationAlias { get; set; }
        public int EmployeeID { get; set; }
        public string BankAccountNumber { get; set; }
        public string IBANNumber { get; set; }
        public bool IsSalaryBank { get; set; }
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

    public class EmployeeFinancialInformationViewModel
    {
        public List<EmployeeFinancialInformationDTO> EmployeeFinancialInformations { get; set; }
        public EmployeeFinancialInformationDTO EmployeeFinancialInformation { get; set; }
    }
}
