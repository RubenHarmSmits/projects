using System;

using Google.Apis.Services;
using Google.Apis.Auth;
using Google.Apis.Oauth2.v2;
using System.Threading.Tasks;

namespace SogyoLunchApp.APIService
{
    public class ExternalLoginInfo
    {
        public IExternalLoginProvider Provider { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
    }

    public class ExternalLoginModel
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
    }

    public class ExternalLoginException : Exception
    {
        public ExternalLoginException(string msg, Exception inner) 
            : base(msg, inner) { }
    }

    public interface IExternalLoginProvider
    {
        string Name { get; }
        Task<ExternalLoginInfo> LoginFromModel(ExternalLoginModel model);
    }

    public class GoogleLoginProvider : IExternalLoginProvider
    {
        public string Name { get { return "Google"; } }

        private readonly Oauth2Service _oauth2Service;
        public GoogleLoginProvider(Oauth2Service oath2service) {
            _oauth2Service = oath2service;
        }

        public async Task<ExternalLoginInfo> LoginFromModel(ExternalLoginModel model)
        {
            try
            {
                await GoogleJsonWebSignature.ValidateAsync(model.IdToken, 
                    new GoogleJsonWebSignature.ValidationSettings {
                        ExpirationTimeClockTolerance = TimeSpan.FromSeconds(30)
                });
            }
            catch (Exception ex)
            {
                throw new ExternalLoginException($"Google authentication failed: {ex.Message}", ex);
            }
            var tokenInfoReq = new Oauth2Service.TokeninfoRequest(_oauth2Service)
            {
                IdToken = model.IdToken
            };
            var tokenInfo = await tokenInfoReq.ExecuteAsync();
            return new ExternalLoginInfo {
                Provider = this,
                UserId = tokenInfo.UserId,
                UserEmail = tokenInfo.Email
            };
        }
    }
}