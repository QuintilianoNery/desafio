using Microsoft.AspNetCore.Mvc.Rendering;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Web.ViewModels
{
    public class CheckoutViewModel
    {
        public int IdFormaPagamento { get; set; }
        public SelectList FormasPagamento { get; set; }
        public double Total { get; set; }
        public int NumItens { get; set; }
    }
}