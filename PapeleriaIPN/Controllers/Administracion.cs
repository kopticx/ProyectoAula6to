using Microsoft.AspNetCore.Mvc;

namespace PapeleriaIPN.Controllers
{
    public class Administracion : Controller
    {
        public IActionResult Principal()
        {
            return View();
        }

        public IActionResult AgregarProducto()
        {
            return View();
        }

        public IActionResult VerTransacciones()
        {
            return View();
        }

        public IActionResult AdministrarInventario()
        {
            return View();
        }
    }
}
