using Frontend.Models;
using Frontend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly Api _api;

        public VeiculoController()
        {
            _api = new Api();
        }

        public async Task<ActionResult> Index()
        {
            var veiculos = await _api.GetVeiculo();
            return View(veiculos);
        }

        public async Task<ActionResult> Details(int id)
        {
           var veiculo = await _api.GetVeiculo(id);
            return View(veiculo);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Veiculo model)
        {
            try
            {
                await _api.PostVeiculo(model, HttpMethod.Post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var veiculo = await _api.GetVeiculo(id);
            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Veiculo model)
        {
            try
            {
                await _api.PutVeiculo(id, model, HttpMethod.Put);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
          var veiculo = await _api.GetVeiculo(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var veiculo = await _api.DeleteVeiculo(id, HttpMethod.Delete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
