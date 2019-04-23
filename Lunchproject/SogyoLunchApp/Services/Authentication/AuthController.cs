using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SogyoLunchApp.APIService
{

    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly Func<string, IExternalLoginProvider> _loginProviders;
        private readonly JwtIssuer _jwtIssuer;
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(
            Func<string, IExternalLoginProvider> loginProviders,
            JwtIssuer jwtIssuer,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AuthController> logger
        )
        {
            _loginProviders = loginProviders;
            _jwtIssuer = jwtIssuer;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost(nameof(Refresh))]
        public async Task<ActionResult> Refresh([FromBody] string refreshToken) {
            var user = await _userManager.GetUserAsync(this.User);
            var storedToken = await _userManager.GetAuthenticationTokenAsync(
                user,
                RefreshTokenProvider.Name,
                RefreshTokenProvider.Purpose
            );
            if (!refreshToken.Equals(storedToken)) {
                return Unauthorized();
            }
            var isValid = await _userManager.VerifyUserTokenAsync(
                user,
                RefreshTokenProvider.Name,
                RefreshTokenProvider.Purpose,
                refreshToken
            );
            if (!isValid) {
                return Unauthorized();
            }
            var accessToken = _jwtIssuer.IssueToken(
                user,
                await _userManager.GetRolesAsync(user)
            );
            return Ok(accessToken);
        }

        [HttpPost(nameof(Logout))]
        public async Task<ActionResult> Logout() {
            var user = await _userManager.GetUserAsync(this.User);
            await _signInManager.SignOutAsync();
            // Invalidate the stored token by updated the security stamp
            await _userManager.UpdateSecurityStampAsync(user);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(nameof(ExternalLogin))]
        public async Task<ActionResult> ExternalLogin([FromBody]ExternalLoginModel model) {
            if (!this.ModelState.IsValid) {
                return BadRequest(new {
                    Errors = this.ModelState.Errors()
                });
            }
            var loginProvider = _loginProviders(model.Provider);
            if (loginProvider == null) {
                this.ModelState.AddModelError("Provider", $"External authentication provider {model.Provider} not supported");
                return BadRequest(new {
                    Errors = this.ModelState.Errors()
                });
            }
            var externalLoginInfo = (ExternalLoginInfo) null;
            try {
                externalLoginInfo = await loginProvider.LoginFromModel(model);
            } catch (ExternalLoginException ex) {
                this.ModelState.AddModelError("IdToken", ex.Message);
                return Unauthorized(new {
                    Errors = this.ModelState.Errors()
                });
            }
            var loginInfo = new UserLoginInfo(
                loginProvider.Name,
                externalLoginInfo.UserId,
                loginProvider.Name
            );
            var user = await _userManager.FindByEmailAsync(externalLoginInfo.UserEmail);
            if (user == null) {
                user = new AppUser {
                    Id = Guid.NewGuid(),
                    UserName = externalLoginInfo.UserEmail,
                    Email = externalLoginInfo.UserEmail
                };
                var createUserResult = await _userManager
                    .CreateAsync(user);
                if (_userManager.Users.Count() == 1)
                {
                    await _userManager.AddToRoleAsync(user, AppRole.AdminRole);
                }
            }
            // Issue access token
            await _userManager.AddLoginAsync(user, loginInfo);
            await _signInManager.SignInAsync(user, false);
            var accessToken = _jwtIssuer.IssueToken(
                user,
                await _userManager.GetRolesAsync(user)
            );
            // Issue refresh token
            await _userManager.RemoveAuthenticationTokenAsync(
                user, 
                RefreshTokenProvider.Name,
                RefreshTokenProvider.Purpose
            );
            var refreeshToken = await _userManager.GenerateUserTokenAsync(
                user,
                RefreshTokenProvider.Name,
                RefreshTokenProvider.Purpose
            );
            await _userManager.SetAuthenticationTokenAsync(
                user,
                RefreshTokenProvider.Name,
                RefreshTokenProvider.Purpose,
                refreeshToken
            );
            return Ok(new {
                AccessToken = accessToken,
                RefreshToken = refreeshToken
            });
        }
        /*[HttpGet(nameof(ExternalLogin))]
        [AllowAnonymous]
        public ActionResult ExternalLogin(
            [FromQuery] string provider = "Google",
            [FromQuery] string returnUrl = null
        )
        {
            var redirect = Url.Action(
                nameof(ExternalLoginCallback),
                new { ReturnUrl = returnUrl }
            );
            var providerProperties = _signInManager
                .ConfigureExternalAuthenticationProperties(provider, redirect);
            return Challenge(providerProperties, provider);
        }

        [HttpGet(nameof(ExternalLoginCallback))]
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(
            [FromQuery] string returnUrl = null,
            [FromQuery] string remoteError = null
        )
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return Unauthorized();
            }
            var user = await _userManager
                .FindByEmailAsync(info.Principal.FindFirstValue(ClaimTypes.Email));

            if (user != null)
            {
                var signInResult = await _signInManager
                    .ExternalLoginSignInAsync(
                        info.LoginProvider,
                        info.ProviderKey,
                        isPersistent: false
                    );
            }
            else
            {
                user = new AppUser
                {
                    Id = Guid.NewGuid(),
                    UserName = info.Principal
                        .FindFirstValue(ClaimTypes.Email),
                    Email = info.Principal
                        .FindFirstValue(ClaimTypes.Email),
                    GivenName = info.Principal
                        .FindFirstValue(ClaimTypes.GivenName),
                    Surname = info.Principal
                        .FindFirstValue(ClaimTypes.Surname),
                    Picture = info.Principal
                        .FindFirstValue(AppUser.PictureClaim)
                };

                var createUserResult = await _userManager
                    .CreateAsync(user);
                if (_userManager.Users.Count() == 1)
                {
                    await _userManager.AddToRoleAsync(user, AppUserRole.AdminRole);
                }
                var addLoginResult = await _userManager
                    .AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, false);
            }

            return Json(new
            {
                Id = user.Id,
                Email = user.Email,
                GivenName = user.GivenName,
                Surname = user.Surname,
                Picture = user.Picture,
                ReturnUrl = returnUrl
            });
        } */

        // step 1: get Project in google, and set user secrets to ClientID and ClientSecret

        // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-2.2
        // https://www.jerriepelser.com/blog/authenticate-oauth-aspnet-core-2
        // https://developers.google.com/oauthplayground/


    }
}
