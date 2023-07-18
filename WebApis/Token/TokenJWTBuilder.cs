using Microsoft.IdentityModel.Tokens;

namespace WebApis.Token
{
    public class TokenJWTBuilder
    {
        private SecurityKey securityKey = null;
        private string subject = "";
        private string issuer = "";
        private string audience = "";
        private Dictionary<string, string> claims  = new Dictionary<string, string>();
        private int expiryInMinutes = 5;

        public TokenJWTBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.securityKey = securityKey;
            return this;
        }

        public TokenJWTBuilder AddSecuritySubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public TokenJWTBuilder AddSecurityIssuer(string issuer)
        {
            this.issuer = issuer;
            return this;
        }

        public TokenJWTBuilder AddSecurityAudience(string audience)
        {
            this.audience = audience;
            return this;
        }

        public TokenJWTBuilder AddClaim(string type, string value)
        {
            this.claims.Add(type, value);
            return this;
        }
    }
}
