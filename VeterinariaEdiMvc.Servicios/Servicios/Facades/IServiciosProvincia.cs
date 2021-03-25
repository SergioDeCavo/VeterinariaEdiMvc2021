using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosProvincia
    {
        List<ProvinciaListDto> GetLista();
        ProvinciaEditDto GetProvinciaPorId(int? id);
        void Guardar(ProvinciaEditDto provincia);
        void Borrar(int? id);
        bool Existe(ProvinciaEditDto provincia);
        bool EstaRelacionado(ProvinciaEditDto provinciaDto);
    }
}
