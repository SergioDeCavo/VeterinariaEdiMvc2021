using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeTareas
    {
        List<TipoDeTareaListDto> GetLista();
        TipoDeTareaEditDto GetipoDeTareaPorId(int? id);
        void Guardar(TipoDeTarea tipoDeTarea);
        void Borrar(int? id);
        bool Existe(TipoDeTarea tipoDeTarea);
        bool EstaRelacionado(TipoDeTarea tipoDeTarea);
    }
}
