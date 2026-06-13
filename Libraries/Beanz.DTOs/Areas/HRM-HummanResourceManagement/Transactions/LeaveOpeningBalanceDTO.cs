using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Transactions
{
    public class LeaveOpeningBalanceDTO
    {
        public int LeaveOpeningBalanceID { get; set; }
        public int LeavePolicyID { get; set; }
        public int LeaveTypeID { get; set; }
        public int OpeningBalanceStatusID { get; set; }
        public string LeaveOpeningBalanceCode { get; set; }
        public DateTime LeaveOpeningBalanceDate { get; set; }
        public int EmployeeID { get; set; }
        public int BalanceDays { get; set; }
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

    public class LeaveOpeningBalanceViewModel
    {
        public List<LeaveOpeningBalanceDTO> LeaveOpeningBalances { get; set; }
        public LeaveOpeningBalanceDTO LeaveOpeningBalance { get; set; }
    }
}
