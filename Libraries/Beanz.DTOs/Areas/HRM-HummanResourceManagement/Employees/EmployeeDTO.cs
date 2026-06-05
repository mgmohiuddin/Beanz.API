using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Employees
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public int GenderID { get; set; }
        public int ReligionID { get; set; }
        public int NationalityID { get; set; }
        public int MaritialStatusID { get; set; }
        public int EmployeeStatusID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAlias { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FamilyName { get; set; }
        public string FirstNameAlias { get; set; }
        public string MiddleNameAlias { get; set; }
        public string LastNameAlias { get; set; }
        public string FamilyNameAlias { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmployeePicture { get; set; }
        public string OldoldEmployeeCode { get; set; }
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

    public class EmployeeViewModel
    {
        public List<EmployeeDTO> Employees { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
