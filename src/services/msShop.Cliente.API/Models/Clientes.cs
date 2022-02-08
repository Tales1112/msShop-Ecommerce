using mShop.Core.DomainObjects;
using System;

namespace msShop.Cliente.API.Models
{
    public class Clientes : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Cpf Cpf { get; set; }
        public bool Excluido { get;private set; }
        public Endereco Endereco { get; private set; }

        //EF Relation
        protected Clientes()
        {
        }
        public Clientes(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Excluido = false;
        }
        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }
        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
