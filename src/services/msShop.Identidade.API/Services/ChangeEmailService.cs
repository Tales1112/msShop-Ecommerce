using Microsoft.AspNetCore.Identity;
using mShop.Core.Communication;
using msShop.Identidade.API.Data;
using msShop.Identidade.API.Model;
using System.Threading.Tasks;

namespace msShop.Identidade.API.Services
{
    public class ChangeEmailService
    {
        public readonly UserManager<Usuario> _userManager;

        public ChangeEmailService(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> ChangeEmail(ChangeEmail changeEmailViewModel)
        {
            var User = await _userManager.FindByEmailAsync(changeEmailViewModel.OldEmail);
            var emailToken = await _userManager.GenerateChangeEmailTokenAsync(User, changeEmailViewModel.NewEmail);

            var result = await _userManager.ChangeEmailAsync(User, changeEmailViewModel.NewEmail, emailToken);

            return result;
        }
    }
}
