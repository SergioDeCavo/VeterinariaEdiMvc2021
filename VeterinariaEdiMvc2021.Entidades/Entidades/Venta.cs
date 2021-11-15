using System;
using System.Collections.Generic;
using System.Linq;

namespace VeterinariaEdiMvc2021.Entidades.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public bool Anulado { get; set; }
        public Cliente Cliente { get; set; }
        public virtual ICollection<ItemVenta> ItemVentas { get; set; }

        public decimal TotalVenta => ItemVentas.Sum(d => d.PrecioVenta * (decimal)d.Cantidad);
    }
}
