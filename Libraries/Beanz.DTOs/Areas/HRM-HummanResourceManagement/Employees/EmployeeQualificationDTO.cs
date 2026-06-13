using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Employees
{
    public class EmployeeQualificationDTO
    {
        public int EmployeeQualificationID { get; set; }
        public string EmployeeQualificationCode { get; set; }
        public string EmployeeQualificationName { get; set; }
        public string EmployeeQualificationAlias { get; set; }
        public int EmployeeID { get; set; }
        public string InstitudeName { get; set; }
        public int CompletedYear { get; set; }
        public string PassLevel { get; set; }
        public decimal Marks { get; set; }
        public decimal Percentage { get; set; }
        public string CertificateAttachment { get; set; }
        public string MarkSheetAttachment { get; set; }
        public string OtherAttachments { get; set; }
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

    public class EmployeeQualificationViewModel
    {
        public List<EmployeeQualificationDTO> EmployeeQualifications { get; set; }
        public EmployeeQualificationDTO EmployeeQualification { get; set; }
    }
}
