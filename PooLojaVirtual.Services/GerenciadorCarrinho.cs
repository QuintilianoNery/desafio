using System.Linq;
using Microsoft.EntityFrameworkCore;
using PooLojaVirtual.Core;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Services
{
    public class GerenciadorCarrinho : IGerenciadorCarrinho
    {
        private readonly IRepositorio<Carrinho> _repositorio;

        public GerenciadorCarrinho(IRepositorio<Carrinho> repositorio)
        {
            _repositorio = repositorio;
        }

        public void LimparCarrinho()
        {
            _repositorio.Excluir(RecuperarCarrinho());
        }

        public Carrinho RecuperarCarrinho()
        {
            var carrinho = _repositorio.GetAll()
                .Include(c => c.Itens)
                .ThenInclude(item => item.Produto)
                .FirstOrDefault();

            if (carrinho == null)
            {
                carrinho = new Carrinho();
            }
            return carrinho;
        }

        public void Salvar(Carrinho carrinho)
        {
            if (carrinho.Id == 0)
            {
                _repositorio.Inserir(carrinho);
            }
            else
            {
                _repositorio.Salvar(carrinho);
            }
        }
    }
}