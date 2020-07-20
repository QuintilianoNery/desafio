using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PooLojaVirtual.Core;
using PooLojaVirtual.Infraestructure;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio<Produto> _repositorio;

        public HomeController(IRepositorio<Produto> repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View(_repositorio.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
