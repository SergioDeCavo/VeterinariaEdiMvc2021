using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosDroga
    {
        List<DrogaListDto> GetLista();
        DrogaEditDto GetDrogaPorId(int? id);
        void Guardar(DrogaEditDto droga);
        void Borrar(int? id);
        bool Existe(DrogaEditDto droga);
    }
}
