using System;
using System.Collections.Generic;

namespace PooLojaVirtual.Models
{
    public class Pedido : Entidade
    {
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public IEnumerable<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();
        public double Valor { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
    }
}