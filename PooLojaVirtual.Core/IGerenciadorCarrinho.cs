using PooLojaVirtual.Models;

namespace PooLojaVirtual.Core
{
    public interface IGerenciadorCarrinho
    {
         Carrinho RecuperarCarrinho();
        void Salvar(Carrinho carrinho);
        void LimparCarrinho();
    }
}