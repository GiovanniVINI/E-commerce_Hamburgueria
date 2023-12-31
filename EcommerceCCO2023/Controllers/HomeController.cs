using EcommerceCCO2023.Models;
using EcommerceCCO2023.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace EcommerceCCO2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ProdutoData data = new ProdutoData();
            return View(data.Read());
        }

        public IActionResult OrdenarPorPrecoCrescente()
        {
            ProdutoData data = new ProdutoData();
            var produtosOrdenadosPorPreco = data.Read().OrderBy(p => p.Valor).ToList();
            return View("Index", produtosOrdenadosPorPreco);
        }

        public IActionResult OrdenarPorPrecoDecrescente()
        {
            ProdutoData data = new ProdutoData();
            var produtosOrdenadosPorPreco = data.Read().OrderByDescending(p => p.Valor).ToList();
            return View("Index", produtosOrdenadosPorPreco);
        }

        public IActionResult OrdenarPorNome()
        {
            ProdutoData data = new ProdutoData();
            var produtosOrdemAlfabetica = data.Read().OrderBy(p => p.NomeProd).ToList();
            return View("Index", produtosOrdemAlfabetica);
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