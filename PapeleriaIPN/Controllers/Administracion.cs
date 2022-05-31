using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PapeleriaIPN.Models;

namespace PapeleriaIPN.Controllers
{
    public class Administracion : Controller
    {
        private readonly PapeleriaContext context;
        private readonly IConfiguration configuration;

        public Administracion(PapeleriaContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public IActionResult Principal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProducto(AgregarProducto productoAdd)
        {
            Producto producto = new Producto()
            {
                NombreProducto = productoAdd.NombreProducto,
                Descripcion = productoAdd.Descripcion,
                Precio = productoAdd.Precio,
                Cantidad = productoAdd.Cantidad
            };

            UploadImage upload = new UploadImage(configuration);
            producto.ImagenUrl1 = upload.Upload(productoAdd.Url);

            context.Add(producto);
            context.SaveChanges();

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
