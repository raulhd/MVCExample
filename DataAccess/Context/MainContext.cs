using DataAccess.Configurations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class MainContext : DbContext, IContext
    {
        public MainContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }

    }
}
