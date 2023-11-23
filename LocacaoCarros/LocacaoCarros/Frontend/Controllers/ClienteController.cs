using Frontend.Models;
using Frontend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Api _api;

        public ClienteController()
        {
            _api = new Api();
        }

        public async Task<ActionResult> Index()
        {
            var clientes = await _api.GetClientes();

            return View(clientes);
        }

        public async Task<ActionResult> Details(int id)
        {
            var cliente = await _api.GetCliente(id);

            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente model)
        {
            try
            {
                await _api.PostCliente(model, HttpMethod.Post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await _api.GetCliente(id);

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Cliente model)
        {
            try
            {
                await _api.PutCliente(id, model, HttpMethod.Put);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _api.GetCliente(id);

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _api.DeleteCliente(id, HttpMethod.Delete);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
