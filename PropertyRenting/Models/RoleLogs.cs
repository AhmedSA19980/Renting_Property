using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoleLogs
    {

       
            public int Id { get; set; }
            public int AdminCommiteeId { get; set; }
            public string AdminCommiteeName { get; set; }
            public int RecipientId { get; set; }
            public string RecipientName { get; set; }
            public byte PrevRole { get; set; } // Matches tinyint
            public byte NewRole { get; set; } // Matches tinyint
            public DateTime DateRoleModified { get; set; }
            public string? Report { get; set; }

            //public ClientsRoleLogsDTO(int Id, int adminCommiteeId, string AdminCommiteeName, int recipientId, string RecipientName,
            //    byte prevRole, byte newRole, DateTime dateRoleModified, string report)
            //{
            //    this.Id = Id;
            //    AdminCommiteeId = adminCommiteeId;
            //    this.AdminCommiteeName = AdminCommiteeName;
            //    RecipientId = recipientId;
            //    this.RecipientName = RecipientName;
            //    PrevRole = prevRole;
            //    NewRole = newRole;
            //    DateRoleModified = dateRoleModified;
            //    Report = report;
            //}
          
        
    }
}
