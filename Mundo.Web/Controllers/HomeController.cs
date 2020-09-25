using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mundo.Web.Models;
using Mundo.Web.Models.Estado;
using Mundo.Web.Models.Home;
using Mundo.Web.Models.Pais;
using Mundo.Web.Models.Pessoa;
using RestSharp;

namespace Mundo.Web.Controllers
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
            var client = new RestClient();

            var requestEstado = new RestRequest("https://localhost:44310/api/Estados");
            var responseEstado = client.Get<List<EstadoViewModel>>(requestEstado);


            var requestPais = new RestRequest("https://localhost:44310/api/Pais");
            var responsePais = client.Get<List<ListarPaisViewModel>>(requestPais);

            var requestAmigos = new RestRequest("https://localhost:44311/api/Amigos");
            var responseAmigos = client.Get<List<ListarPessoasViewModel>>(requestAmigos);


            var pgInicial = new PaginaInicialViewModel
            {
                QuantidadeAmigos = responseAmigos.Data.Count,
                QuantidadeEstados = responseEstado.Data.Count,
                QuantidadePaises = responsePais.Data.Count
            };

            return View(pgInicial);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
