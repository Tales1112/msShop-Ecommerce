using Microsoft.AspNetCore.Mvc;
using mShop.Core.Mediator;
using mShop.WEbApi.Core.Controllers;
using mShop.WEbApi.Core.Usuario;
using msShop.Cliente.API.Application.Commands;
using msShop.Cliente.API.Data.Repository;
using System.Threading.Tasks;

namespace msShop.Cliente.API.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public ClienteController(IClienteRepository clienteRepository, IMediatorHandler mediator, IAspNetUser user)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
            _user = user;
        }

        [HttpGet("cliente/endereco")]
        public async Task<IActionResult> ObterEndereco()
        {
            var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

            return endereco == null ? NotFound() : CustomResponse(endereco);
        }

        [HttpPost("cliente/endereco")]
        public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
        {
            endereco.ClienteId = _user.ObterUserId();
            return CustomResponse(await _mediator.EnviarComando(endereco));
        }
    }
}

