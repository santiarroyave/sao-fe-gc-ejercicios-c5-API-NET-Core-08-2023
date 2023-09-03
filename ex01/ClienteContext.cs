using ex01.Models;
using Microsoft.EntityFrameworkCore;

namespace ex01
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ClienteContext(DbContextOptions<ClienteContext> options) :base(options) { }
    }
}
