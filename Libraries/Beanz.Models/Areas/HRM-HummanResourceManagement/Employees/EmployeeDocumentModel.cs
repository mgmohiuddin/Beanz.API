using System;

namespace Beanz.Models.Areas.HumanResourceManagement.Employees.Objects
{
    // Entity model generated from table structure
    public class EmployeeDocument
    {
        public int EmployeeDocumentID { get; set; }
        public int DocumentTypeID { get; set; }
        public int DocumentSubmissionTypeID { get; set; }
        public string EmployeeDocumentCode { get; set; }
        public string EmployeeDocumentName { get; set; }
        public string EmployeeDocumentAlias { get; set; }
        public int EmployeeID { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentIssueDate { get; set; }
        public string DocumentIssuePlace { get; set; }
        public DateTime DocumentExpireDate { get; set; }
        public int NotificationDays { get; set; }
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
