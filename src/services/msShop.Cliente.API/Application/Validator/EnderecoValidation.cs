using FluentValidation;
using msShop.Cliente.API.Application.Commands;

namespace msShop.Cliente.API.Application.Validator
{
    public class EnderecoValidation : AbstractValidator<AdicionarEnderecoCommand>
    {
        public EnderecoValidation()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty()
                .WithMessage("Informe o Logradouro");

            RuleFor(c => c.Numero)
                .NotEmpty()
                .WithMessage("Informe o Numero");

            RuleFor(c => c.Cep)
                .NotEmpty()
                .WithMessage("Informe o CEP");

            RuleFor(c => c.Bairro)
                .NotEmpty()
                .WithMessage("Informe o Bairro");

            RuleFor(c => c.Cidade)
                .NotEmpty()
                .WithMessage("Informe o Cidade");

            RuleFor(c => c.Estado)
                .NotEmpty()
                .WithMessage("Informe o Estado");
        }
    }
}
