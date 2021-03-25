using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosFormaFarmaceutica
    {
        List<FormaFarmaceuticaListDto> GetLista();
        FormaFarmaceuticaEditDto GetFormaFarmaceuticaPorId(int? id);
        void Guardar(FormaFarmaceuticaEditDto formaFarmaceutica);
        void Borrar(int? id);
        bool Existe(FormaFarmaceuticaEditDto formaFarmaceutica);
    }
}
