using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Models.Common
{
    //internal class EmailNotification
    //{
    ////}
    //[Table("EmailNotificationTbl", Schema = "dbo")]
    public class EmailNotification
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("ID")]
        public long ID { get; set; }

        [Required, EmailAddress, StringLength(256)] 
        public string MessageFrom { get; set; } = default!;

        // Semicolon/comma separated list of recipients
        [Required, StringLength(4000)] 
        public string MessageTo { get; set; } = default!;

        [EmailAddress, StringLength(4000)] 
        public string? MessageCc { get; set; }

        [EmailAddress, StringLength(4000)] 
        public string? MessageBcc { get; set; }

        [Required, StringLength(500)] 
        public string MessageSubject { get; set; } = default!;

        [Required] 
        [DataType(DataType.Html)]
        public string MessageBody { get; set; } = default!;

        // Pending | Sent | Failed | Retry
        [Required, StringLength(20)] 
        public string MessageStatus { get; set; } = "Pending";

        [StringLength(200)] 
        public string? SMTPServer { get; set; }

        [Range(1, 65535)] 
        public int? Port { get; set; }

        [StringLength(200)] 
        public string? DisplayName { get; set; }

        // Semicolon separated absolute paths or JSON array of file paths
    
        public string? FileAttachments { get; set; }
         
        public string? ErrorDesc { get; set; }

        //[Required] 
        //public Guid UniqueID { get; set; } = Guid.NewGuid();

        // Transaction type e.g. OTP | MFA | ResetPassword | Welcome | Notification
        [StringLength(50)] 
        public string? TranType { get; set; }
         
        public int? CompanyID { get; set; }
    }
}
