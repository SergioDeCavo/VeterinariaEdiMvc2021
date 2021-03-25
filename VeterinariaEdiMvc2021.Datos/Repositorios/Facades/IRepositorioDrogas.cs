using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioDrogas
    {
        List<DrogaListDto> GetLista();
        DrogaEditDto GetDrogaPorId(int? id);
        void Guardar(Droga droga);
        void Borrar(int? id);
        bool Existe(Droga droga);
    }
}
