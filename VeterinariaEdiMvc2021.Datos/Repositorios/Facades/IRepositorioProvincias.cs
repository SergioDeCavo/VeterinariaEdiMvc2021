using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<ProvinciaListDto> GetLista();
        ProvinciaEditDto GetProvinciaPorId(int? id);
        void Guardar(Provincia provincia);
        void Borrar(int? id);
        bool Existe(Provincia provincia);
        bool EstaRelacionado(Provincia provincia);
    }
}
