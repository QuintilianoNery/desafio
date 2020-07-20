using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PooLojaVirtual.Core;

namespace PooLojaVirtual.Web.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoService _servicoPedidos;

        public PedidosController(IPedidoService servicoPedidos)
        {
            _servicoPedidos = servicoPedidos;
        }

        public IActionResult Index()
        {
            var pedidos = _servicoPedidos.RecuperarPedidos()
                .OrderByDescending(p => p.Data);
            return View(pedidos);
        }
    }
}