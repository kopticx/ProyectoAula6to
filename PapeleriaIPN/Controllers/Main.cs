using Microsoft.AspNetCore.Mvc;
using PapeleriaIPN.Models;
using System.Linq;

namespace PapeleriaIPN.Controllers
{
    public class Main : Controller
    {
        private readonly PapeleriaContext context;

        public Main(PapeleriaContext context)
        {
            this.context = context;
        }

        public IActionResult Principal()
        {
            var productos = context.Productos.Take(4).ToList();

            return View(productos);
        }

        public IActionResult Productos()
        {
            var productos = context.Productos.ToList();

            return View(productos);
        }

        public IActionResult InfoProducto(int id)
        {
            var producto = context.Productos.Where(x => x.IdProducto == id).First();

            return View(producto);
        }
    }
}
