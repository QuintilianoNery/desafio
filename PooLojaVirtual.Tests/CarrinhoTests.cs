using System.Linq;
using PooLojaVirtual.Models;
using Xunit;

namespace PooLojaVirtual.Tests
{
    public class CarrinhoTests
    {
        [Fact]
        public void Carrinho_Deve_Ser_Criado_Vazio()
        {
            var carrinho = new Carrinho();

            Assert.Empty(carrinho.Itens);
            Assert.Equal(0, carrinho.Total);
        }

        [Fact]
        public void Carrinho_Deve_Conter_Produto_Adicionado()
        {
            var carrinho = new Carrinho();
            var produto = new Produto
            {
                Descricao = "Notebook",
                Nome = "Notebook"
            };

            carrinho.Adicionar(produto, 1);

            Assert.Single(carrinho.Itens);
        }

        [Fact]
        public void Carrinho_Deve_Somar_Os_Produtos()
        {
            var carrinho = new Carrinho();
            var produto1 = new Produto
            {
                Id = 1,
                Descricao = "Notebook",
                Nome = "Notebook",
                Preco = 2000
            };
            var produto2 = new Produto
            {
                Id = 2,
                Descricao = "Smartphone",
                Nome = "Smartphone",
                Preco = 1000
            };

            carrinho.Adicionar(produto1, 2);
            carrinho.Adicionar(produto2, 3);

            Assert.Equal(2, carrinho.Itens.Count());
            var item1 = Assert.Single(carrinho.Itens, item => item.Produto.Equals(produto1));
            var item2 = Assert.Single(carrinho.Itens, item => item.Produto.Equals(produto2));
            Assert.Equal(4000, item1.Subtotal);
            Assert.Equal(3000, item2.Subtotal);
            Assert.Equal(7000, carrinho.Total);
        }

        [Fact]
        public void Carrinho_Deve_Remover_Produto()
        {
            var carrinho = new Carrinho();
            var produto = new Produto
            {
                Id = 1,
                Nome = "Notebook"
            };

            carrinho.Adicionar(produto, 1);
            Assert.NotEmpty(carrinho.Itens);
            carrinho.Remover(produto.Id);
            Assert.Empty(carrinho.Itens);
        }
    }
}
