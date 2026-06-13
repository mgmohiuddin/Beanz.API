using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Transactions
{
    public class LeaveDTO
    {
        public int LeaveID { get; set; }
        public int LeavePolicyID { get; set; }
        public int LeaveTypeID { get; set; }
        public int LeaveStatusID { get; set; }
        public int LeaveRequisitionID { get; set; }
        public string LeaveCode { get; set; }
        public DateTime LeaveDate { get; set; }
        public int EmployeeID { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public int TotalDays { get; set; }
        public int PaidDays { get; set; }
        public int UnPaidDays { get; set; }
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

    public class LeaveViewModel
    {
        public List<LeaveDTO> Leaves { get; set; }
        public LeaveDTO Leave { get; set; }
    }
}
