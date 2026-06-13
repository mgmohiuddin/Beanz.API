using System;

namespace Beanz.Models.Areas.HumanResourceManagement.Policies.Objects
{
    // Entity model generated from table structure
    public class BusinessTripPolicyPayment
    {
        public int BusinessTripPolicyPaymentID { get; set; }
        public int BusinessTripPolicyID { get; set; }
        public int AllowanceTypeID { get; set; }
        public int AllowanceID { get; set; }
        public int BusinessTripPayTypeID { get; set; }
        public string BusinessTripPolicyPaymentCode { get; set; }
        public string BusinessTripPolicyPaymentName { get; set; }
        public string BusinessTripPolicyPaymentAlias { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal FixedAmount { get; set; }
        public int FromDays { get; set; }
        public int ToDays { get; set; }
        public decimal AmountPerDay { get; set; }
        public bool IsAsPerInvoice { get; set; }
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
