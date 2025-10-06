using ApiSolicitudes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSolicitudes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Solicitudes> Solicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
