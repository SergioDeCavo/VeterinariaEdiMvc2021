using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioItemVentas
    {
        List<ItemVentaListDto> GetItemVentas();
    }
}
