using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosTipoDeTarea
    {
        List<TipoDeTareaListDto> GetLista();
        TipoDeTareaEditDto GetipoDeTareaPorId(int? id);
        void Guardar(TipoDeTareaEditDto tipoDeTarea);
        void Borrar(int? id);
        bool Existe(TipoDeTareaEditDto tipoDeTarea);
    }
}
