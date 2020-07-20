using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PooLojaVirtual.Infraestructure
{
    public class LojaSqliteContextFactory : IDesignTimeDbContextFactory<LojaSqLiteDbContext>
    {
        public LojaSqliteContextFactory()
        {

        }
        public LojaSqLiteDbContext CreateDbContext(string[] args)
        {
            var configuration = ConfigurationService.GetConfig();
            var optionsBuilder = new DbContextOptionsBuilder<LojaDbContext>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("LojaDbContext"));

            return new LojaSqLiteDbContext(optionsBuilder.Options, configuration);
        }
    }
}