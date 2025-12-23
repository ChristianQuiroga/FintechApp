using FintechApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FintechApp.Controllers
{
    public class ClienteController : Controller
    {
        private static List<Cliente> clientes = new();

        public IActionResult Index()
        {
            return View(clientes);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {
            cliente.IdCliente = clientes.Count + 1;
            clientes.Add(cliente);
            return RedirectToAction("Index");
        }
    }
}
