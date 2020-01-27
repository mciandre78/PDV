using Microsoft.EntityFrameworkCore;
using pdv.Models;

namespace pdv.Data
{
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) {
            
        }

        public DbSet<Pdv> Pdvs { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}