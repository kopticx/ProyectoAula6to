using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PapeleriaIPN.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdUser { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingresa un direccion de correo valida")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Name { get; set; }
        public byte? UserType { get; set; }

        public virtual TipoUsuario UserTypeNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
