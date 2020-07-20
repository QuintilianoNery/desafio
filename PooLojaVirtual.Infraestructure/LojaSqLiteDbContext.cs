using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PooLojaVirtual.Infraestructure
{
    public class LojaSqLiteDbContext : LojaDbContext
    {
        private readonly IConfiguration _configuration;

        public LojaSqLiteDbContext(DbContextOptions<LojaDbContext> options, IConfiguration configuration) 
            : base(options, configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(_configuration.GetConnectionString("LojaDbContext"));
    }
}