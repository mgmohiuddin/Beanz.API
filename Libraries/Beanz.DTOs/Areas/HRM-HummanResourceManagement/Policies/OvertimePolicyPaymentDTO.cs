using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Policies
{
    public class OvertimePolicyPaymentDTO
    {
        public int OvertimePolicyPaymentID { get; set; }
        public int OverTimePolicyID { get; set; }
        public int AllowanceID { get; set; }
        public int AllowanceTypeID { get; set; }
        public string OvertimePolicyPaymentCode { get; set; }
        public string OvertimePolicyPaymentName { get; set; }
        public string OvertimePolicyPaymentAlias { get; set; }
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

    public class OvertimePolicyPaymentViewModel
    {
        public List<OvertimePolicyPaymentDTO> OvertimePolicyPayments { get; set; }
        public OvertimePolicyPaymentDTO OvertimePolicyPayment { get; set; }
    }
}
