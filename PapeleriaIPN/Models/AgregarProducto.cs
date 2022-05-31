using System.ComponentModel.DataAnnotations;

namespace PapeleriaIPN.Models
{
    public class AgregarProducto
    {
        [Required(ErrorMessage = "Este campo es necesario")]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string Url { get; set; }
    }
}
