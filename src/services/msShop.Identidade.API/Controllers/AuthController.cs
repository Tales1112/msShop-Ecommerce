using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mShop.Core.Messages.Integration;
using mShop.MessageBus;
using mShop.WEbApi.Core.Controllers;
using msShop.Identidade.API.Data;
using msShop.Identidade.API.Model;
using msShop.Identidade.API.Services;
using System;
using System.Threading.Tasks;

namespace msShop.Identidade.API.Controllers
{
    [Route("api/identidade")]
    public class AuthController : MainController
    {
        private readonly AuthenticationService _authenticationService;
        private readonly ChangeEmailService _changeEmailService;
        private readonly IMessageBus _Bus;

        public AuthController(AuthenticationService authenticationService, IMessageBus Bus,
                              ChangeEmailService changeEmailService)
        {
            _authenticationService = authenticationService;
            _changeEmailService = changeEmailService;
            _Bus = Bus;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new Usuario
            {
                Nome = usuarioRegistro.Nome,           
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _authenticationService._userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                var clienteResult = await RegistrarCliente(usuarioRegistro);
                if (!clienteResult.ValidationResult.IsValid)
                {
                    await _authenticationService._userManager.DeleteAsync(user);
                    return CustomResponse(clienteResult.ValidationResult);
                }
                return CustomResponse(await _authenticationService.GerarJwt(usuarioRegistro.Email));
            }

            foreach (var erro in result.Errors)
            {
                AdicionarErroProcessamento(erro.Description);
            }
            return CustomResponse();
        }
        [HttpPost("autenticar")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resull = await _authenticationService._signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);

            if (resull.Succeeded)
            {
                return CustomResponse(await _authenticationService.GerarJwt(usuarioLogin.Email));
            }

            if (resull.IsLockedOut)
            {
                AdicionarErroProcessamento("Usuario temporariamente bloqueado por tentatias invalidas");
                return CustomResponse();
            }

            AdicionarErroProcessamento("Usuario ou Senha Incorretos");
            return CustomResponse();
        }
        [HttpPost("change-email")]
        public async Task<IActionResult> ChangeEmail(ChangeEmail changeEmail)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _changeEmailService.ChangeEmail(changeEmail);

            if(result.Succeeded)
            {
                return CustomResponse();
            }

            foreach (var erro in result.Errors)
            {
                AdicionarErroProcessamento(erro.Description);
            }

            return CustomResponse();
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                AdicionarErroProcessamento("Refresh token invalido");
                return CustomResponse();
            }

            var token = await _authenticationService.ObterRefreshToken(Guid.Parse(refreshToken));

            if (token is null)
            {
                AdicionarErroProcessamento("Refresh Token expirado");
                return CustomResponse();
            }

            return CustomResponse(await _authenticationService.GerarJwt(token.UserName));
        }

        private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistro usuarioRegistro)
        {
            var usuario = await _authenticationService._userManager.FindByEmailAsync(usuarioRegistro.Email);

            var usuarioRegistrado = new UsuarioRegistradoIntegrationEvent(Guid.Parse(usuario.Id), usuarioRegistro.Nome, usuarioRegistro.Email, usuarioRegistro.Cpf);

            try
            {
                return await _Bus.RequestAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(usuarioRegistrado);
            }
            catch (Exception)
            {
                await _authenticationService._userManager.DeleteAsync(usuario);
                throw;
            }
        }
    }
}
