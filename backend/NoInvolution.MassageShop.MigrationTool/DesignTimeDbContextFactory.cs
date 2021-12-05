using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NoInvolution.MassageShop.EntityFramework;

namespace NoInvolution.MassageShop.MigrationTool
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MassageDbContext>
    {
        public MassageDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MassageDbContext>();
            var dbStr = @"Host=localhost;Port=54320;Database=massage_db;Username=postgres;Password=a12345";
            optionsBuilder.UseNpgsql(dbStr, x => x.MigrationsAssembly("NoInvolution.MassageShop.MigrationTool"));

            return new MassageDbContext(optionsBuilder.Options, null);
        }
    }
}
