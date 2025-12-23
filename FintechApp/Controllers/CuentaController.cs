using FintechApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FintechApp.Controllers
{
    public class CuentaController : Controller
    {
        private static List<Cuenta> cuentas = new();

        public IActionResult Index()
        {
            return View(cuentas);
        }
    }
}
