using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using mShop.WEbApi.Core.Usuario;
using msShop.Models;
using msShop.Services;
using msShop.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Controllers
{
    public class IdentidadeController : MainController
    {
        private readonly IAutenticacaoService _autenticacaoService;
        private readonly IAspNetUser _user;
        public IdentidadeController(IAutenticacaoService autenticacaoService, IAspNetUser aspNetUser)
        {
            _autenticacaoService = autenticacaoService;
            _user = aspNetUser;
        }

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            var resposta = await _autenticacaoService.Registro(usuarioRegistro);

            if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioRegistro);

            await _autenticacaoService.RealizarLogin(resposta);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [Route("ExternalLogin")]
        public  async  Task<IActionResult> ExternalLogin(string provider,string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Identidade", new { ReturnUrl = returnUrl });

            var properties = await _autenticacaoService.GetExternalLoginAuthenticationProperties(new ExternalLogin { Provider = provider, ReturnUrl = redirectUrl });

            return new ChallengeResult(provider, properties);   
        }

        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var token = await _user.ObterHttpContext().GetTokenAsync(GoogleDefaults.AuthenticationScheme, "id_token");

            var resposta = await _autenticacaoService.LoginExternal(token);

            if (ResponsePossuiErros(resposta.ResponseResult)) return View();

            await _autenticacaoService.RealizarLogin(resposta);

            return LocalRedirect(returnUrl);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if(!ModelState.IsValid) return View(usuarioLogin);

            var resposta = await _autenticacaoService.Login(usuarioLogin);

            if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioLogin);

            await _autenticacaoService.RealizarLogin(resposta);

            if (string.IsNullOrEmpty(returnUrl)) return  RedirectToAction("Index", "Home");

            return LocalRedirect(returnUrl);
        }
        [HttpGet]
        [Route("ChangeEmail")]
        public IActionResult ChangeEmail()
        {
            return View();
        }
        [HttpPost]
        [Route("ChangeEmail")]
        public async Task<IActionResult> ChangeEmail(ChangeEmailViewModel changeEmailViewModel)
        {
            if (!ModelState.IsValid) return View(changeEmailViewModel);

            var resposta = await _autenticacaoService.ChangeEmail(changeEmailViewModel);

            if (ResponsePossuiErros(resposta)) TempData["Erros"] =
                     ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("Manager", "Manage");
        }
        [HttpPost]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            await _autenticacaoService.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}
