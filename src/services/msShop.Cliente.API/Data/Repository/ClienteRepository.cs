using Microsoft.EntityFrameworkCore;
using mShop.Core.Data;
using msShop.Cliente.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace msShop.Cliente.API.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _context;

        public ClienteRepository(ClientesContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;
        public void Adicionar(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Endereco> ObterEnderecoPorId(Guid id)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Clientes> ObterPorCpf(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Cpf.Numero == cpf);
        }

        public async Task<IEnumerable<Clientes>> ObterTodos()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }
    }
}
