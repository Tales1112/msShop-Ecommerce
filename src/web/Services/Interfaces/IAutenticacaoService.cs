using Microsoft.AspNetCore.Authentication;
using mShop.Core.Communication;
using msShop.Models;
using msShop.ViewModels;
using System.Threading.Tasks;

namespace msShop.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        Task Logout();
        Task<UsuarioRespostaLogin> LoginExternal(string token);
        Task RealizarLogin(UsuarioRespostaLogin resposta);
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
        Task<AuthenticationProperties> GetExternalLoginAuthenticationProperties(ExternalLogin externalLogin);
        Task<ResponseResult> ChangeEmail(ChangeEmailViewModel changeEmailViewModel);
    }
}