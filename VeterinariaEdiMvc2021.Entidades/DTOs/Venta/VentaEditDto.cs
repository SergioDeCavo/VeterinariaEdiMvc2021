using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Venta
{
    public class VentaEditDto
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public bool Anulado { get; set; }
    }
}
