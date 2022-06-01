using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PapeleriaIPN.Models;
using System;
using System.Linq;

namespace PapeleriaIPN.Controllers
{
    public class Main : Controller
    {
        private readonly PapeleriaContext context;
        private readonly IConfiguration configuration;

        public Main(PapeleriaContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
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

        [HttpPost]
        public IActionResult Contacto(Contacto contacto)
        {
            SendEmail send = new(configuration);
            send.Contacto(contacto.Nombre, contacto.Correo, contacto.Mensaje);

            return RedirectToAction("Contacto");
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompraRealizada(CompraRealizada compra)
        {
            var pedido = new Pedido();

            var producto = context.Productos.Where(x => x.IdProducto == compra.IdProducto).First();

            pedido.IdProducto = compra.IdProducto;
            pedido.IdUsuario = InicioSesion.usuarioGlobal.IdUser;
            pedido.Cantidad = compra.Cantidad;
            pedido.Total = compra.Cantidad * producto.Precio;
            pedido.FechaPedido = DateTime.Now;

            context.Add(pedido);
            
            producto.Cantidad -= pedido.Cantidad;
            context.Update(producto);
            context.SaveChanges();

            return View(producto);
        }
    }
}
