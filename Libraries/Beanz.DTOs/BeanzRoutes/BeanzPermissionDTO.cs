using System;
using System.Collections.Generic;
using System.Text;
using Beanz.DTOs.Common;

namespace Beanz.DTOs.BeanzRoutes
{
   public class BeanzPermissionDTO :BeanzCommonDTO
    {
        public long? CompanyRolePermissionID { get; set; }

        public long? ScreenID { get; set; }
        public string Area { get; set; }
        public string AreaSubFolder { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; } 
        public bool IsInsert { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public bool IsPost { get; set; }
        public bool IsImport { get; set; }
        public bool IsExport { get; set; }
        public bool IsSendEmail { get; set; }
        public bool IsViewCharts { get; set; } 
        public bool IsViewHistory { get; set; }
        public string SchemaCode { get; set; }
        public string ScreenTableName { get; set; }
        public long? SystemScreenID { get; set; } 
    }
}
