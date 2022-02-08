using FluentValidation.Results;
using mShop.Core.Messages;
using mShop.Core.Messages.Integration;
using System.Threading.Tasks;

namespace mShop.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
