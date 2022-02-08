using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mShop.WEbApi.Core.Identidade;
using mShop.WEbApi.Core.Usuario;
using msShop.Identidade.API.Data;
using msShop.Identidade.API.Extensions;
using msShop.Identidade.API.Model;
using NetDevPack.Security.Jwt.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace msShop.Identidade.API.Services
{
    public class AuthenticationService
    {
        public readonly SignInManager<IdentityUser> _signInManager;
        public readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly AppTokenSettings _appTokenSettings;
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly IJsonWebKeySetService _jwsService;
        private readonly IAspNetUser _aspNetUser;
        public AuthenticationService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, 
                                     AppSettings appSettings, AppTokenSettings appTokenSettings, 
                                     ApplicationDbContext applicationDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings;
            _appTokenSettings = appTokenSettings;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<UsuarioRespostaLogin> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimUsuario(claims, user);
            var encodedToken = CodificarToken(identityClaims);

            var refreshToken = await GerarRefreshToken(email);

            return ObterRespostaToken(encodedToken, user, claims, refreshToken);
        }
        private  async Task<ClaimsIdentity> ObterClaimUsuario(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity(claims);
            return identityClaims;
        }
        private string CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var currentIssuer = $"{_aspNetUser.ObterHttpContext().Request.Scheme}://{_aspNetUser.ObterHttpContext().Request.Host}";

            var key = _jwsService.GenerateSigningCredentials();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = currentIssuer,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = key
            });

            return tokenHandler.WriteToken(token);
        }
        private UsuarioRespostaLogin ObterRespostaToken(string encodedToken, IdentityUser user,
                                                        IEnumerable<Claim> claims, RefreshToken refreshToken)
        {
            return new UsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = TimeSpan.FromHours(1).TotalSeconds,
                UsuarioToken = new UsuarioToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaim { Type = c.Type, Value = c.Value })
                }
            };
        }
        private async Task<RefreshToken> GerarRefreshToken(string email)
        {
            var refreshToken = new RefreshToken
            {
                UserName = email,
                ExpirationDate = DateTime.UtcNow.AddHours(_appTokenSettings.RefreshTokenExpiration)
            };

            //Remove antigos RefreshTokens
            _applicationDbContext.RemoveRange(_applicationDbContext.RefreshTokens.Where(u => u.UserName == email));

            await _applicationDbContext.SaveChangesAsync();

            return refreshToken;
        }
        public async Task<RefreshToken> ObterRefreshToken(Guid refreshToken)
        {
            var token = await _applicationDbContext.RefreshTokens.AsNoTracking()
                            .FirstOrDefaultAsync(u => u.Token == refreshToken);

            return token != null && token.ExpirationDate.ToLocalTime() > DateTime.Now ? token : null;

        }
        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    }
}
