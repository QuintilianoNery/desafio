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
                return Itens.Sum(item => item.Subtotal);
            }
        }

        public void Adicionar(Produto produto, int quantidade)
        {
            var item  = itens.Find(item => item.Produto.Id == produto.Id);
            if( item == null){
                itens.Add(new ItemCarrinho(produto, quantidade));
            }
            else
            {
                item.Quantidade += quantidade;
            }
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