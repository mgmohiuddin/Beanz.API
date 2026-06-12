using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts
{
    public class AccountTypeDTO
    {
        public int AccountTypeID { get; set; }
        public string AccountTypeCode { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeAlias { get; set; }
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

    public class AccountTypeViewModel
    {
        public List<AccountTypeDTO> AccountTypes { get; set; }
        public AccountTypeDTO AccountType { get; set; }
    }
}
