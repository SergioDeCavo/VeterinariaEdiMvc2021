using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosLaboratorio
    {
        List<LaboratorioListDto> GetLista();
        LaboratorioEditDto GetLaboratorioPorId(int? id);
        void Guardar(LaboratorioEditDto laboratorio);
        void Borrar(int? id);
        bool Existe(LaboratorioEditDto laboratorio);
        bool EstaRelacionado(LaboratorioEditDto laboratorioDto);
    }
}
