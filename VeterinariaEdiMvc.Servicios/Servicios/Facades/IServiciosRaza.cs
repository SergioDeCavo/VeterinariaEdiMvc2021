using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosRaza
    {
        List<RazaListDto> GetLista(string descripcion);
        bool Existe(RazaEditDto razaEditDto);
        void Guardar(RazaEditDto razaDto);
        RazaEditDto GetRazaPorId(int? id);
        void Borrar(int razaId);
        bool EstaRelacionado(RazaEditDto razaDto);
    }
}
