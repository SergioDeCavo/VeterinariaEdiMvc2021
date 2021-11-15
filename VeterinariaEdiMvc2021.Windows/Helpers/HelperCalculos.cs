using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Windows.Helpers
{
    public class HelperCalculos
    {
        public static decimal CalcularTotalOrden(ICollection<ItemVenta> itemVentas)
        {
            return itemVentas.Sum(d => d.PrecioVenta * d.Cantidad);
        }
    }
}
