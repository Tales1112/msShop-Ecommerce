using FluentValidation;
using mShop.Core.DomainObjects;
using msShop.Cliente.API.Application.Commands;
using System;

namespace msShop.Cliente.API.Application.Validator
{
    public class RegistrarClienteValidation : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente nao foi informado");

            RuleFor(c => c.Cpf)
                .Must(TerCpfValido)
                .WithMessage("O cpf informado não é válido.");

            RuleFor(c => c.Email)
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é válido.");
        }
        protected static bool TerCpfValido(string cpf)
        {
            return Cpf.Validar(cpf);
        }
        protected static bool TerEmailValido(string email)
        {
            return Email.Validar(email); 
        }
    }
}
