using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Employees
{
    public class EmployeeOfficialInformationDTO
    {
        public int EmployeeOfficialInformationID { get; set; }
        public int OrganizationID { get; set; }
        public int GradeID { get; set; }
        public int SubGradeID { get; set; }
        public int PositionID { get; set; }
        public int DesignationID { get; set; }
        public int RegionID { get; set; }
        public int SectionID { get; set; }
        public int SubSectionID { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public int AreaID { get; set; }
        public int SubOrganizationID { get; set; }
        public int DepartmentID { get; set; }
        public int SubDepartmentID { get; set; }
        public int BranchID { get; set; }
        public string EmployeeOfficialInformationCode { get; set; }
        public string EmployeeOfficialInformationName { get; set; }
        public string EmployeeOfficialInformationAlias { get; set; }
        public int EmployeeID { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ContractFromDate { get; set; }
        public DateTime ContractToDate { get; set; }
        public int NoticePeriodDays { get; set; }
        public string RegisteredMobile { get; set; }
        public string RegisteredEmail { get; set; }
        public string BiometricID { get; set; }
        public string ResidenceIDNumber { get; set; }
        public DateTime ResidenceIDExpireDate { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportExpireDate { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExtention { get; set; }
        public int ReportingManagerID { get; set; }
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

    public class EmployeeOfficialInformationViewModel
    {
        public List<EmployeeOfficialInformationDTO> EmployeeOfficialInformations { get; set; }
        public EmployeeOfficialInformationDTO EmployeeOfficialInformation { get; set; }
    }
}
