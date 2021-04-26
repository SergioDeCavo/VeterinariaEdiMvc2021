using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioLocalidades
    {
        List<LocalidadListDto> GetLista(string nombreProvincia);
        bool Existe(Localidad localidad);
        void Guardar(Localidad localidad);
        LocalidadEditDto GetLocalidadPorId(int? id);
        void Borrar(int localidadId);
    }
}
