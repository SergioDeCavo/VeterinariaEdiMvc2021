using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeServicios
    {
        List<TipoDeServicioListDto> GetLista();
        TipoDeServicioEditDto GetipoDeServicioPorId(int? id);
        void Guardar(TipoDeServicio tipoDeServicio);
        void Borrar(int? id);
        bool Existe(TipoDeServicio tipoDeServicio);
    }
}
