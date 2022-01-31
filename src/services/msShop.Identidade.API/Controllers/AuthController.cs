using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mShop.Core.Messages.Integration;
using mShop.WEbApi.Core.Controllers;
using msShop.Identidade.API.Data;
using msShop.Identidade.API.Services;
using System;
using System.Threading.Tasks;

namespace msShop.Identidade.API.Controllers
{
    [Route("api/identidade")]
    public class AuthController : MainController
    {
        private readonly AuthenticationService _authenticationService;

        public AuthController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _authenticationService._userManager.CreateAsync(user, usuarioRegistro.senha);

            if (result.Succeeded)
            {
                var clienteResult = await RegistrarCliente(usuarioRegistro);
            }
        }
        private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistro usuarioRegistro)
        {
            var usuario = await _authenticationService._userManager.FindByEmailAsync(usuarioRegistro.Email);

            var usuarioRegistrado = new UsuarioRegistradoIntegrationEvent(Guid.Parse(usuario.Id), usuarioRegistro.Nome, usuarioRegistro.Email, usuarioRegistro.Cpf);
            await _authenticationService._userManager.CreateAsync(usuario);

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
