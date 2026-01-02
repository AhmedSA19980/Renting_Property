

namespace SharedDTOLayer.clients.clientsDTO
{
    public class AddClientRoleLogDTO
    {
        public int AdminCommiteeId { get; set; }
        public int RecipientId { get; set; }
        public byte RecipientRole { get; set; } // Matches tinyint
        public string Report { get; set; }

        public AddClientRoleLogDTO(int adminCommiteeId, int recipientId, byte recipientRole, string report)
        {
            AdminCommiteeId = adminCommiteeId;
            RecipientId = recipientId;

            RecipientRole = recipientRole;

            Report = report;
        }



        // You could also add an Id property if you need it,
        // to match the primary key of the clientRoleLog table.
        // public int Id { get; set; }
    }
}
