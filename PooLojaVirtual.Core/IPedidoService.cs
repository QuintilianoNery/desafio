using System.Linq;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Core
{
    public interface IPedidoService
    {
         IQueryable<Pedido> RecuperarPedidos();
    }
}