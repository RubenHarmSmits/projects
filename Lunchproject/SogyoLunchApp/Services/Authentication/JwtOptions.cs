using Microsoft.IdentityModel.Tokens;

namespace SogyoLunchApp.APIService {
    public class JwtOptions {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
        public int RefreshExpiryHours { get; set; }
        public SigningCredentials Credentials { get; set; }
    }
}