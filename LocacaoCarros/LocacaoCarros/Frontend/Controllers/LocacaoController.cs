using Frontend.Models;
using Frontend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly Api _api;

        public LocacaoController()
        {
            _api = new Api();
        }

        public async Task<ActionResult> Index()
        {
            var locacoes = await _api.GetLocacao();

            return View(locacoes);
        }

        public async Task<ActionResult> Details(int id)
        {
            var locacao = await _api.GetLocacao(id);

            return View(locacao);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Locacao model)
        {
            try
            {
                await _api.PostLocacao(model, HttpMethod.Post);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var locacao = await _api.GetLocacao(id);
            
            return View(locacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Locacao model)
        {
            try
            {
                await _api.PutLocacao(id, model, HttpMethod.Put);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var locacao = await _api.GetLocacao(id);
            
            return View(locacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Locacao model)
        {
            try
            {
                await _api.DeleteLocacao(id, HttpMethod.Delete);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}