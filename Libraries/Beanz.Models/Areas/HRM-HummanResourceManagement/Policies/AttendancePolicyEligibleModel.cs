using System;

namespace Beanz.Models.Areas.HummanResourceManagement.Policies.Objects
{
    // Entity model generated from table structure
    public class AttendancePolicyEligible
    {
        public int AttendancePolicyEligibleID { get; set; }
        public int AttendancePolicyID { get; set; }
        public int AreaID { get; set; }
        public int OrganizationID { get; set; }
        public int SubOrganizationID { get; set; }
        public int BranchID { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public int DepartmentID { get; set; }
        public int DesignationID { get; set; }
        public int GenderID { get; set; }
        public int MaritialStatusID { get; set; }
        public int NationalityID { get; set; }
        public int PositionID { get; set; }
        public int RegionID { get; set; }
        public int ReligionID { get; set; }
        public int SectionID { get; set; }
        public int SubDepartmentID { get; set; }
        public int SubGradeID { get; set; }
        public int SubSectionID { get; set; }
        public int GradeID { get; set; }
        public string AttendancePolicyEligibleCode { get; set; }
        public string AttendancePolicyEligibleName { get; set; }
        public string AttendancePolicyEligibleAlias { get; set; }
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
