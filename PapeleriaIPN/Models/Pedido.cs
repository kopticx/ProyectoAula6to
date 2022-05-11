using System;
using System.Collections.Generic;

#nullable disable

namespace PapeleriaIPN.Models
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public int? IdProducto { get; set; }
        public int? IdUsuario { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }
        public DateTime? FechaPedido { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
