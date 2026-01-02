
using System;

namespace SharedDTOLayer.Tokens.TokensDTO
{
    public class RefreshTokenDTO
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplacedByToken { get; set; }
        public string? ReasonRevoked { get; set; }
        public int ClientId { get; set; } // Matches the UserId in your RefreshTokens table


        public RefreshTokenDTO()
        {

            this.Id = -1;
            this.Token = "";
            this.Expires = DateTime.Now;
            this.Created = DateTime.Now;
            this.CreatedByIp = "";
            this.Revoked = DateTime.Now;
            this.RevokedByIp = "";
            this.ReplacedByToken = "";
            this.ReasonRevoked = "";
            this.ClientId = -1;

        }

        public RefreshTokenDTO(int Id, string token, DateTime expires, DateTime created, string createdByIp, DateTime? revoked, string? revokedByIp
            , string? replacedByToken, string? reasonRevoked, int clientID)
        {
            this.Id = Id;
            this.Token = token;
            this.Expires = expires;
            this.Created = created;
            this.CreatedByIp = createdByIp;
            this.Revoked = revoked;
            this.RevokedByIp = revokedByIp;
            this.ReplacedByToken = replacedByToken;
            this.ReasonRevoked = reasonRevoked;
            this.ClientId = clientID;
        }

        // Helper properties
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;
    }

}
