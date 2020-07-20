using System;
using System.IO;
using System.Text;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Infraestructure
{
    public class ServicoEmail : IServicoEmail
    {
        private readonly string NomeArquivo = "email.log";
        public void EnviarConfirmacao(string email, Pedido pedido)
        {
            var texto = new StringBuilder();
            texto.AppendLine($"Destinatário: {email}");
            texto.AppendLine("Assunto: Confirmação do pedido");
            texto.AppendLine("Olá. Seu pedido foi confirmado.");
            texto.AppendLine($"Número do pedido: {pedido.Id}");
            texto.AppendLine($"Forma de pagamento: {pedido.FormaPagamento.Nome}");

            foreach (var item in pedido.Itens)
            {
                texto.AppendLine($"   {item.Produto.Nome} x {item.Quantidade} = ${item.Subtotal}");
            }

            texto.AppendLine($"Total do pedido: ${pedido.Valor}");

            using (var arquivo = new StreamWriter(NomeArquivo, true))
            {
               arquivo.Write(texto.ToString());
               arquivo.WriteLine();
            }
        }
    }
}
