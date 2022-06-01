using System;

namespace PapeleriaIPN.Models
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public string Usuario { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get;  set; }
    }
}
