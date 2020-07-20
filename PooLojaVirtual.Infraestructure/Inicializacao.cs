using System;
using System.Linq;
using PooLojaVirtual.Core;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Infraestructure
{
    public class Inicializacao
    {
        public static void Inicializar(IServiceProvider services)
        {
            var produtos = services.GetService(typeof(IRepositorio<Produto>)) as IRepositorio<Produto>;
            var formasPagamento = services.GetService(typeof(IRepositorio<FormaPagamento>)) as IRepositorio<FormaPagamento>;

            if (produtos.GetAll().Count() == 0)
            {
                produtos.Inserir(new Produto
                {
                    Nome = "HD Externo Portátil WD Elements 1TB USB 3.0",
                    Descricao = @"Guarde seus arquivos de forma segura e portátil com um acessório indispensável para sua vida digital. O HD Externo Portátil WD faz transferências de dados ultrarrápidas e possui 1TB de capacidade.
Com design leve, ele é a companhia perfeita para quem viaja muito, seja a passeio ou a negócios.",
                    Preco = 248,
                    Foto = "hd.png"
                });

                produtos.Inserir(new Produto
                {
                    Nome = "Cartao de memoria Sandisk Micro Sdxc Ultra 100mb/s 128gb",
                    Descricao = @"Cartao de memoria Sandisk Micro Sdxc Ultra 100mb/s 128gb para celular samsung Galaxy S8 S9.",
                    Preco = 248,
                    Foto = "cartao.jpg"
                });

                produtos.Inserir(new Produto
                {
                    Nome = "Capa Case Transparente Samsung Galaxy J7 J710 Metal",
                    Descricao = @"Capa transparente flexível feita em Tpu é um Material Misto Entre Plástico E Silicone Macio.",
                    Preco = 248,
                    Foto = "capa-celular.jpg"
                });

                produtos.Inserir(new Produto
                {
                    Nome = "Console Xbox One S 1tb Branco Com 2 Controles",
                    Descricao = @"Com o novo Xbox One S, você pode assistir a filmes 4K Blu ray, Netflix no deslumbrante 4K Ultra Hd.",
                    Preco = 248,
                    Foto = "xbox.jpg"
                });

                produtos.Inserir(new Produto
                {
                    Nome = "Multifuncional Hp Deskjet 2675",
                    Descricao = @"Facilite suas tarefas diárias com a multifuncional 2675 da HP, ela possui conexão Wireless.",
                    Preco = 248,
                    Foto = "multifuncional.jpg"
                });

                produtos.Inserir(new Produto
                {
                    Nome = "Monitor Gamer LED 25 IPS ultrawide Full HD 25UM58 - LG",
                    Descricao = @"1 Monitor LG; 1 Cabo HDMI; 1 Adaptador AC e Manual de Instruções.",
                    Preco = 248,
                    Foto = "monitor.png"
                });

                produtos.Inserir(new Produto
                {
                    Nome = "Bicicleta MTB Caloi Andes - Aro 26 - 21 velocidades - Preta",
                    Descricao = @" Bike ideal para passeio em parques, ciclovias e terrenos levemente acidentados. .",
                    Preco = 248,
                    Foto = "bicicleta.jpg"
                });
            }

            if (formasPagamento.GetAll().Count() == 0)
            {
                formasPagamento.Inserir(new FormaPagamento
                {
                    Nome = "Boleto"
                });

                formasPagamento.Inserir(new FormaPagamento
                {
                    Nome = "Cartão de crédito"
                });
            }
        }
    }
}