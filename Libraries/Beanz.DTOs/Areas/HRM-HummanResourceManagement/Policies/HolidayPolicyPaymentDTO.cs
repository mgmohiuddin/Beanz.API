using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HumanResourceManagement.Policies
{
    public class HolidayPolicyPaymentDTO
    {
        public int HolidayPolicyPaymentID { get; set; }
        public int HolidayPolicyID { get; set; }
        public int AllowanceTypeID { get; set; }
        public int AllowanceID { get; set; }
        public string HolidayPolicyPaymentCode { get; set; }
        public string HolidayPolicyPaymentName { get; set; }
        public string HolidayPolicyPaymentAlias { get; set; }
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

    public class HolidayPolicyPaymentViewModel
    {
        public List<HolidayPolicyPaymentDTO> HolidayPolicyPayments { get; set; }
        public HolidayPolicyPaymentDTO HolidayPolicyPayment { get; set; }
    }
}
