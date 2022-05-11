using System.ComponentModel.DataAnnotations;

namespace PapeleriaIPN.Models
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Password { get; set; }
    }
}
