using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosItemVenta
    {
        List<ItemVentaListDto> GetItemVentas();
    }
}
