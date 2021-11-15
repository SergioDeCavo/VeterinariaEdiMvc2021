using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta
{
    public class ItemVentaEditDto
    {
        public int ItemVentaId { get; set; }
        public int VentaId { get; set; }
        public int MedicamentoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
