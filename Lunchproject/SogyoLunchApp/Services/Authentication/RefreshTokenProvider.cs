using System;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Newtonsoft.Json;

namespace SogyoLunchApp.APIService {
    public class RefreshToken {
        public DateTime Expiry { get; set; }
        public string SecurityStamp { get; set; }
    }

    public class RefreshTokenProvider : IUserTwoFactorTokenProvider<AppUser> {
        public const string Name = "RefreshTokenProvider";
        public const string Purpose = "Refresh";

        public IDataProtector Protector { get; private set; }
        public JwtOptions Options { get; private set; }

        public RefreshTokenProvider(IDataProtectionProvider protectionProvider, JwtOptions options) {
            Protector = protectionProvider.CreateProtector(RefreshTokenProvider.Name);
            Options = options;
        }

        public async Task<string> GenerateAsync(string purpose, UserManager<AppUser> manager, AppUser user) {
            var token = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new RefreshToken {
                Expiry = DateTime.UtcNow.AddMinutes(Options.RefreshExpiryHours),
                SecurityStamp = await manager.GetSecurityStampAsync(user)
            }));
            return Convert.ToBase64String(Protector.Protect(token));
        }

        public async Task<bool> ValidateAsync(string purpose, string token, UserManager<AppUser> manager, AppUser user) {
            var decoded = Encoding.UTF8.GetString(
                Protector.Unprotect(Convert.FromBase64String(token)
            ));
            var json = JsonConvert.DeserializeObject<RefreshToken>(decoded);
            if (DateTime.Compare(json.Expiry, DateTime.UtcNow) > 0
                || json.SecurityStamp != await manager.GetSecurityStampAsync(user))
            {
                return false;
            }
            return true;
        }

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<AppUser> manager, AppUser user)
        {
            return Task.FromResult(true);
        }
    }
}