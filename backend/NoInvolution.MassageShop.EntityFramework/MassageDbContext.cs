using MiCake.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoInvolution.MassageShop.Domain.PersonnelContext;
using NoInvolution.MassageShop.Domain.ReserveContext;
using NoInvolution.MassageShop.EntityFramework.ReserveContext;

namespace NoInvolution.MassageShop.EntityFramework
{
    public class MassageDbContext : DbContext
    {
        // PersonnelContext
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }

        // ReserveContext
        public DbSet<MassageSchedule> MassageSchedules { get; set; }

        private readonly IServiceProvider _services;
        public MassageDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
        {
            _services = serviceProvider;
        }

        protected MassageDbContext()
        {
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

            modelBuilder.AddPersonnelContextModel()
                        .AddReserveContextModel();
        }
    }
}
