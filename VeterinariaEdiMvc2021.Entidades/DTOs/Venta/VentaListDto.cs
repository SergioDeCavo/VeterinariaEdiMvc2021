using System;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Cliente { get; set; }
        public bool Anulado { get; set; }
    }
}
