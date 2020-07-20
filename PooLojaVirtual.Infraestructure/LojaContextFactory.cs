using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PooLojaVirtual.Infraestructure
{
    public class LojaContextFactory : IDesignTimeDbContextFactory<LojaDbContext>
    {
        public LojaDbContext CreateDbContext(string[] args)
        {
            var configuration = ConfigurationService.GetConfig();
            var optionsBuilder = new DbContextOptionsBuilder<LojaDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("LojaDbContext"));

            return new LojaDbContext(optionsBuilder.Options, configuration);
        }
    }
}