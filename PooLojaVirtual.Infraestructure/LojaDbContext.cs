using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Infraestructure
{
    public class LojaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LojaDbContext(DbContextOptions<LojaDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(_configuration.GetConnectionString("LojaDbContext"));

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
    }
}