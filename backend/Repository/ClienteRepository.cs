using System.Collections.Generic;
using backend.Model;
using System.Linq;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class ClienteRepository : IDataRepository<Cliente>
    {
        readonly EfDbContext _clienteContext;
        // METODO CONSTRUTOR
        public ClienteRepository(EfDbContext context) => _clienteContext = context;


        public void Create(Cliente entity)
        {
            System.Console.WriteLine("CADASTROU CLIENTE");

           _clienteContext.Clientes.Add(entity);
           _clienteContext.SaveChanges();

        }
        public IEnumerable<Cliente> Read()
        {
            System.Console.WriteLine("TROUXE TUDO");
            return _clienteContext.Clientes
                // .Include (r => r.Profissao)
                .ToList();
        }

     
        public Cliente ReadId(int id)
        {
            System.Console.WriteLine("TROUXE CLIENTE IDSETADO");
            return _clienteContext.Clientes
            // .Include(p => p.Profissao)
            .FirstOrDefault(e => e.IdCliente == id);
        }

        public void Delete(Cliente entity)
        {
            System.Console.WriteLine("EXCLUIU");

            _clienteContext.Clientes.Remove(entity);
            _clienteContext.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            System.Console.WriteLine("ATUALIZOU");
            
            _clienteContext.Clientes.Update(cliente);
            _clienteContext.SaveChanges();
            
        }

    }
}