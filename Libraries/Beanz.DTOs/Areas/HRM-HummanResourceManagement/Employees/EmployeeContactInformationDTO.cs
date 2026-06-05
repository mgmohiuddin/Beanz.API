using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Employees
{
    public class EmployeeContactInformationDTO
    {
        public int EmployeeContactInformationID { get; set; }
        public string EmployeeContactInformationCode { get; set; }
        public string EmployeeContactInformationName { get; set; }
        public string EmployeeContactInformationAlias { get; set; }
        public int EmployeeID { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public string POBox { get; set; }
        public string EmailID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Area { get; set; }
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

    public class EmployeeContactInformationViewModel
    {
        public List<EmployeeContactInformationDTO> EmployeeContactInformations { get; set; }
        public EmployeeContactInformationDTO EmployeeContactInformation { get; set; }
    }
}
