using System;

namespace Beanz.Models.Areas.System.Setup.Objects
{
    // Entity model generated from table structure
    public class SystemScreenEndpoint
    {
        public int SystemScreenEndpointID { get; set; }
        public int SystemScreenID { get; set; }
        public string AreaName { get; set; }
        public string SubAreaName { get; set; }
        public string ControllerName { get; set; }
        public string TableName { get; set; }
        public string SchemaName { get; set; }
        public bool IsMain { get; set; }
        public string HttpMethod { get; set; }
        public string HttpRoute { get; set; }
        public string Action { get; set; }
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
