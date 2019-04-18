using System.Collections.Generic;
using backend.Model;
using System.Linq;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class ICliente : IDataRepository<Cliente>
    {
        readonly EfDbContext _clienteContext;
        // METODO CONSTRUTOR
        public ICliente(EfDbContext context)
        {
            _clienteContext = context;
        }

        public IEnumerable<Cliente> Read()
        {
            return _clienteContext.Clientes
                .Include (r => r.Profissao)
                .ToList();
        }

        public void Create(Cliente entity)
        {
           _clienteContext.Clientes.Add(entity);
           _clienteContext.SaveChanges();
        }

        public void Delete(Cliente entity)
        {
            _clienteContext.Clientes.Remove(entity);
            _clienteContext.SaveChanges();
        }

        public Cliente ReadId(int id)
        {
            return _clienteContext.Clientes
            .FirstOrDefault(e => e.IdCliente == id);
        }

        public void Update(Cliente cliente, Cliente entity)
        {
            _clienteContext.Clientes.Update(entity);
            _clienteContext.SaveChanges();
            
        }
    }
}