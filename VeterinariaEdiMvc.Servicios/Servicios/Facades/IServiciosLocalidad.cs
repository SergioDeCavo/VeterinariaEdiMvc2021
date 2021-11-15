using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosLocalidad
    {
        List<LocalidadListDto> GetLista(string nombreProvincia);
        bool Existe(LocalidadEditDto localidadEditDto);
        void Guardar(LocalidadEditDto localidadDto);
        LocalidadEditDto GetLocalidadPorId(int? id);
        bool EstaRelacionado(LocalidadEditDto localidadDto);
        void Borrar(int localidadId);
        List<Localidad> GetLista(int provinciaId);
        List<Localidad> GetLista();
    }
}
