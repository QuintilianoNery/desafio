using System.Linq;
using Microsoft.EntityFrameworkCore;
using PooLojaVirtual.Core;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IRepositorio<Pedido> _repositorioPedidos;

        public PedidoService(IRepositorio<Pedido> repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public IQueryable<Pedido> RecuperarPedidos()
        {
            return _repositorioPedidos.GetAll()
                .Include(p => p.FormaPagamento);
        }
    }
}