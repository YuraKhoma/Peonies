using Peonies.Models;
using System.Data.Entity;

namespace Peonies.DataBaseAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Peony> Peonies { get; set; }
        public DbSet<PeonyType> PeonyTypes { get; set; }
        public DbSet<Variety> Varieties { get; set; }
    }
}
