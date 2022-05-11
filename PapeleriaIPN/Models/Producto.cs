using System;
using System.Collections.Generic;

#nullable disable

namespace PapeleriaIPN.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string ImagenUrl { get; set; }
        public int? Cantidad { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
