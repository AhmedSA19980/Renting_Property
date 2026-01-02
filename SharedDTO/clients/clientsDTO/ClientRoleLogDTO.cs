using System;


namespace SharedDTOLayer.clients.clientsDTO
{
    public class ClientRoleLogDTO
    {
        public int AdminCommiteeId { get; set; }
        public string AdminCommiteeName { get; set; }
        public int RecipientId { get; set; }
        public string RecipientName { get; set; }
        public byte OldRole { get; set; } // Matches tinyint
        public byte RecipientRole { get; set; } // Matches tinyint
        public DateTime DateRoleModified { get; set; }
        public string Report { get; set; }

        public ClientRoleLogDTO(int adminCommiteeId, string AdminCommiteeName, int recipientId, string RecipientName, byte oldRole, byte recipientRole, DateTime dateRoleModified, string report)
        {
            this.AdminCommiteeId = adminCommiteeId;
            this.AdminCommiteeName = AdminCommiteeName;
            this.RecipientId = recipientId;
            this.RecipientName = RecipientName;
            this.OldRole = oldRole;
            this.RecipientRole = recipientRole;
            this.DateRoleModified = dateRoleModified;
            this.Report = report;
        }



        // You could also add an Id property if you need it,
        // to match the primary key of the clientRoleLog table.
        // public int Id { get; set; }
    }

}
