using System;

namespace Beanz.Models.Areas.HumanResourceManagement.Transactions.Objects
{
    // Entity model generated from table structure
    public class LeaveDay
    {
        public int LeaveDayID { get; set; }
        public int LeaveID { get; set; }
        public string LeaveDayCode { get; set; }
        public DateTime LeaveDayDate { get; set; }
        public int EmployeeID { get; set; }
        public bool IsPaid { get; set; }
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
