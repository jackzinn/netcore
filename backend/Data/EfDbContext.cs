using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions options):base (options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }


    }
}