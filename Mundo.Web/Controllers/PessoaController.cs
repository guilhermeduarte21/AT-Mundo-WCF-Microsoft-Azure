using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mundo.Web.ApiServices;
using Mundo.Web.ApiServices.Pessoa;
using Mundo.Web.Models.Pessoa;

namespace Mundo.Web.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaApi _pessoaApi;

        public PessoaController(IPessoaApi pessoaApi)
        {
            _pessoaApi = pessoaApi;
        }



        // GET: PessoaController
        public ActionResult Index()
        {
            var Lista = new List<ListarPessoasViewModel>();

            return View(Lista);
        }

        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            var result = await _pessoaApi.PostAsync(criarPessoaViewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
