namespace PooLojaVirtual.Models
{
    public class ItemCarrinho : Entidade
    {
        public ItemCarrinho(Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
        }

        public ItemCarrinho()
        {

        }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public double Subtotal
        {
            get
            {
                return Produto.Preco * Quantidade;
            }
        }
    }
}