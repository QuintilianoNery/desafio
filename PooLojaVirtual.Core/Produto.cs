using System;

namespace PooLojaVirtual.Models
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Foto { get; set; }
    }
}
