using System;

namespace Beanz.Models.Areas.FinancialAccountingSystem.Transactions.Objects
{
    // Entity model generated from table structure
    public class AccountOpeningDetail
    {
        public int AccountOpeningDetailID { get; set; }
        public int AccountOpeningID { get; set; }
        public DateTime AccountOpeningDetailDate { get; set; }
        public string AccountOpeningDetailNumber { get; set; }
        public string AccountOpeningDetailCode { get; set; }
        public string AccountOpeningDetailName { get; set; }
        public string AccountOpeningDetailAlias { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public int CurrencyID { get; set; }
        public int AccountID { get; set; }
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
