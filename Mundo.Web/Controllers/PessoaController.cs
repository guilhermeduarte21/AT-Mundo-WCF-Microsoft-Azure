using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mundo.Web.Models.Pessoa;
using RestSharp;

namespace Mundo.Web.Controllers
{
    public class PessoaController : Controller
    {
        private readonly string _UriAPI = "https://localhost:44311/";

        // GET: PessoaController
        public ActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "api/Amigos");

            var response = client.Get<List<ListarPessoasViewModel>>(request);

            return View(response.Data);
        }

        // GET: PessoaController/Details/5
        public ActionResult Details(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "api/Amigos/" + id, DataFormat.Json);

            var response = client.Get<PessoasViewModel>(request);

            return View(response.Data);
        }

        // GET: PessoaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarPessoaViewModel criarPessoaViewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(criarPessoaViewModel);

                var client = new RestClient();
                var request = new RestRequest(_UriAPI + "api/Amigos", DataFormat.Json);

                request.AddJsonBody(criarPessoaViewModel);

                var response = await client.PostAsync<CriarPessoaViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "api/Amigos/" + id, DataFormat.Json);

            var response = client.Get<PessoasViewModel>(request);

            return View(response.Data);
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, EditarPessoaViewModel editarPessoaViewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(editarPessoaViewModel);

                var client = new RestClient();
                var request = new RestRequest(_UriAPI + "api/Amigos/" + id, DataFormat.Json);

                request.AddJsonBody(editarPessoaViewModel);

                var response = client.Put<EditarPessoaViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var client = new RestClient();
            var request = new RestRequest(_UriAPI + "api/Amigos/" + id, DataFormat.Json);

            var response = client.Get<PessoasViewModel>(request);

            return View(response.Data);
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, PessoasViewModel pessoasViewModel)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(_UriAPI + "api/Amigos/" + id, DataFormat.Json);

                request.AddJsonBody(pessoasViewModel);

                var response = client.Delete<PessoasViewModel>(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
