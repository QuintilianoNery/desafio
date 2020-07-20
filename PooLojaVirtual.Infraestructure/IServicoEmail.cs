using System;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Infraestructure
{
    public interface IServicoEmail
    {
        void EnviarConfirmacao(string email, Pedido pedido);
    }
}