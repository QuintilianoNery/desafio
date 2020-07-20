using System.Collections.Generic;
using System.Linq;

namespace PooLojaVirtual.Models
{
    public class Carrinho : Entidade
    {
        private List<ItemCarrinho> itens = new List<ItemCarrinho>();

        public IEnumerable<ItemCarrinho> Itens => itens;

        public double Total
        {
            get
            {
                return Itens.Sum(item => item.Produto.Preco);
            }
        }

        public void Adicionar(Produto produto, int quantidade)
        {
            itens.Add(new ItemCarrinho(produto, quantidade));
        }

        public void Remover(int idProduto)
        {
            var itemNoCarrinho = Itens.FirstOrDefault(item => item.Produto.Id == idProduto);
            if (itemNoCarrinho != null)
            {
                itens.Remove(itemNoCarrinho);
            }
        }
    }
}