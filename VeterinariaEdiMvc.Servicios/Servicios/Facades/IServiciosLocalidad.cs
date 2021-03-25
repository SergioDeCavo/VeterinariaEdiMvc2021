using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosLocalidad
    {
        List<LocalidadListDto> GetLista();
        bool Existe(LocalidadEditDto localidadEditDto);
        void Guardar(LocalidadEditDto localidadDto);
        LocalidadEditDto GetLocalidadPorId(int? id);
        bool EstaRelacionado(LocalidadEditDto localidadDto);
        void Borrar(int localidadId);
    }
}
