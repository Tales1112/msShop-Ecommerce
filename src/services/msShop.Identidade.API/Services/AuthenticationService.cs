using Microsoft.AspNetCore.Identity;
using mShop.WEbApi.Core.Identidade;
using msShop.Identidade.API.Data;
using msShop.Identidade.API.Extensions;

namespace msShop.Identidade.API.Services
{
    public class AuthenticationService
    {
        public readonly SignInManager<IdentityUser> _signInManager;
        public readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly AppTokenSettings _appTokenSettings;
        private readonly ApplicationDbContext _applicationDbContext;

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


    }
}
