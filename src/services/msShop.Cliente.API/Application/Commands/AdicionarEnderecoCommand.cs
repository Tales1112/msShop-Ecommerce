using mShop.Core.Messages;
using msShop.Cliente.API.Application.Validator;
using System;

namespace msShop.Cliente.API.Application.Commands
{
    public class AdicionarEnderecoCommand : Command
    {
        public Guid ClienteId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public AdicionarEnderecoCommand() { }

        public AdicionarEnderecoCommand(Guid clienteId, string logradouro, string numero, string complemento,
            string bairro, string cep, string cidade, string estado)
        {
            ClienteId = clienteId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }
        public override bool EhValido()
        {
            ValidationResult = new EnderecoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
