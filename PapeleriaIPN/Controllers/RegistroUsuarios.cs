using Microsoft.AspNetCore.Mvc;
using PapeleriaIPN.Models;
using System.Linq;

namespace PapeleriaIPN.Controllers
{
    public class RegistroUsuarios : Controller
    {
        private readonly PapeleriaContext context;

        public RegistroUsuarios(PapeleriaContext context)
        {
            this.context = context;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            var existe = context.Usuarios.ToList().Any(x => x.UserName == usuario.UserName);

            if (!existe)
            {
                usuario.Password = Encrypt.GetSHA256(usuario.Password);
                usuario.UserType = 2;

                context.Add(usuario);
                context.SaveChanges();

                return RedirectToAction("Login", "InicioSesion");
            }
            else
            {
                ViewBag.Incorrecto = false;

                return View();
            }
        }
    }
}
