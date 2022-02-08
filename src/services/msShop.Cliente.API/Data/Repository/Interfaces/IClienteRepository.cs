using mShop.Core.Data;
using msShop.Cliente.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace msShop.Cliente.API.Data.Repository
{
    public interface IClienteRepository : IRepository<Clientes>
    {
        void Adicionar(Clientes cliente);
        void AdicionarEndereco(Endereco endereco);
        Task<IEnumerable<Clientes>> ObterTodos();
        Task<Clientes> ObterPorCpf(string cpf);
        Task<Endereco> ObterEnderecoPorId(Guid id);
    }
}