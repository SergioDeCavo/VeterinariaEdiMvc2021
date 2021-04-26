using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioFormaFarmaceuticas
    {
        List<FormaFarmaceuticaListDto> GetLista();
        FormaFarmaceuticaEditDto GetFormaFarmaceuticaPorId(int? id);
        void Guardar(FormaFarmaceutica formaFarmaceutica);
        void Borrar(int? id);
        bool Existe(FormaFarmaceutica formaFarmaceutica);
        bool EstaRelacionado(FormaFarmaceutica formaFarmaceutica);
    }
}
