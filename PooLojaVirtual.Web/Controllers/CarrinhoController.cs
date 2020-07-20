using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PooLojaVirtual.Infraestructure;
using PooLojaVirtual.Models;
using PooLojaVirtual.Core;

namespace PooLojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IRepositorio<Produto> _repositorio;
        private readonly IGerenciadorCarrinho _gerenciadorCarrinho;

        public CarrinhoController(IRepositorio<Produto> repositorio, IGerenciadorCarrinho gerenciadorCarrinho)
        {
            _repositorio = repositorio;
            _gerenciadorCarrinho = gerenciadorCarrinho;
        }

        public IActionResult Index()
        {
            return View(_gerenciadorCarrinho.RecuperarCarrinho());
        }

        public IActionResult Adicionar(int id)
        {
            var produto = _repositorio.RecuperarPorId(id);
            var carrinho = _gerenciadorCarrinho.RecuperarCarrinho();
            carrinho.Adicionar(produto, 1);
            _gerenciadorCarrinho.Salvar(carrinho);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remover(int id)
        {
            var carrinho = _gerenciadorCarrinho.RecuperarCarrinho();
            carrinho.Remover(id);
            _gerenciadorCarrinho.Salvar(carrinho);
            return RedirectToAction(nameof(Index));
        }
    }
}