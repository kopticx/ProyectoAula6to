﻿using Microsoft.AspNetCore.Mvc;
using PapeleriaIPN.Models;
using System.Linq;

namespace PapeleriaIPN.Controllers
{
    public class InicioSesion : Controller
    {
        private readonly PapeleriaContext context;

        public InicioSesion(PapeleriaContext context)
        {
            this.context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            var existe = context.Usuarios.ToList().Any(x => x.UserName == usuario.UserName && x.Password == Encrypt.GetSHA256(usuario.Password));

            if (existe)
            {
                return Redirect("https://www.youtube.com/watch?v=JUxITamPWrY");
            }
            else
            {
                ViewBag.Incorrecto = true;

                return View();
            }
        }
    }
}
