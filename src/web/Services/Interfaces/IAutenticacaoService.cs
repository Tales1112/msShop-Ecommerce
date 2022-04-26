using mShop.Core.Communication;
using msShop.ViewModels;
using System.Threading.Tasks;

namespace msShop.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        Task Logout();
        Task RealizarLogin(UsuarioRespostaLogin resposta);
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
        Task<ResponseResult> ChangeEmail(ChangeEmailViewModel changeEmailViewModel);
    }
}