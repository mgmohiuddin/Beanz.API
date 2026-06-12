using System;

namespace Beanz.Models.Areas.FinancialAccountingSystem.Transactions.Objects
{
    // Entity model generated from table structure
    public class AccountOpening
    {
        public int AccountOpeningID { get; set; }
        public DateTime AccountOpeningDate { get; set; }
        public string AccountOpeningNumber { get; set; }
        public string AccountOpeningCode { get; set; }
        public string AccountOpeningName { get; set; }
        public string AccountOpeningAlias { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public int CurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
        public int FiscalYearID { get; set; }
        public int BranchID { get; set; }
        public int OrganizationID { get; set; }
        public int VoucherTypeID { get; set; }
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
