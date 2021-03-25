using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosTipoDeServicio
    {
        List<TipoDeServicioListDto> GetLista();
        TipoDeServicioEditDto GetipoDeServicioPorId(int? id);
        void Guardar(TipoDeServicioEditDto tipoDeServicio);
        void Borrar(int? id);
        bool Existe(TipoDeServicioEditDto tipoDeServicio);
    }
}
