using System.ComponentModel.DataAnnotations;

namespace PapeleriaIPN.Models
{
    public class Contacto
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingresa un correo valido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Mensaje { get; set; }
    }
}
