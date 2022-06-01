using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PapeleriaIPN.Models;
using System.Linq;

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
            var pedidoDTO = (from a in context.Pedidos.ToList()
                             join b in context.Productos.ToList()
                             on a.IdProducto equals b.IdProducto
                             join c in context.Usuarios.ToList()
                             on a.IdUsuario equals c.IdUser
                             select new PedidoDTO()
                             {
                                 IdPedido = a.IdPedido,
                                 Usuario = c.UserName,
                                 NombreProducto = b.NombreProducto,
                                 Cantidad = a.Cantidad,
                                 Total = a.Total,
                                 Fecha = a.FechaPedido

                             }).ToList();

            return View(pedidoDTO);
        }

        [HttpPost]
        public IActionResult AdministrarInventario(updateProducto productoUpd)
        {
            if(productoUpd.Accion == "Update")
            {
                var producto = context.Productos.Where(x => x.IdProducto == productoUpd.Id).First();
                producto.Cantidad = productoUpd.Cantidad;
                producto.Precio = productoUpd.Precio;

                context.Update(producto);
                context.SaveChanges();
            }
            else
            {
                var producto = context.Productos.Where(x => x.IdProducto == productoUpd.Id).First();
                context.Remove(producto);
                context.SaveChanges();
            }

            var productos = context.Productos.ToList();

            return View(productos);
        }

        public IActionResult AdministrarInventario()
        {
            var productos = context.Productos.ToList();

            return View(productos);
        }
    }
}
