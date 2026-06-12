using System;

namespace Beanz.Models.Areas.FinancialAccountingSystem.Accounts.Objects
{
    // Entity model generated from table structure
    public class ChartOfAccountCodeSetting
    {
        public int ChartOfAccountCodeSettingID { get; set; }
        public string ChartOfAccountCodeSettingCode { get; set; }
        public string ChartOfAccountCodeSettingName { get; set; }
        public string ChartOfAccountCodeSettingAlias { get; set; }
        public int LevelNo { get; set; }
        public string LevelCodeFormat { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool IsUseParenLevelCode { get; set; }
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
