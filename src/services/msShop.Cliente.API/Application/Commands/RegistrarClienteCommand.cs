﻿using mShop.Core.Messages;
using msShop.Cliente.API.Application.Validator;
using System;

namespace msShop.Cliente.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get;private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegistrarClienteCommand(Guid id, string nome, string email, string cpf )
        {
            AggregatedId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
        public override bool EhValido()
        {
            ValidationResult = new RegistrarClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
