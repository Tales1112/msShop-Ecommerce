using Microsoft.AspNetCore.Mvc;
using mShop.Core.Communication;
using System.Linq;

namespace msShop.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if(resposta != null && resposta.Errors.Mensagens.Any())
            {
                foreach(var mensagem in resposta.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }
            }
            return false;
        }
        protected void AdicionarErroValidacao(string message)
        {
            ModelState.AddModelError(string.Empty, message);
        }
        protected bool OperacaoValid()
        {
            return ModelState.ErrorCount == 0;
        }
    }
}
