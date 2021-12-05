using MiCake.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NoInvolution.MassageShop.EntityFramework
{
    public class MassageDbContext : DbContext
    {
        private readonly IServiceProvider _services;
        public MassageDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
        {
            _services = serviceProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.AddMiCakeConfigure(_services);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddMiCakeModel();
        }
    }
}
