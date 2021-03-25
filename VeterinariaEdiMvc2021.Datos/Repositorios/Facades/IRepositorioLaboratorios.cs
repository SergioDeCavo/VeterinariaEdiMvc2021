using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioLaboratorios
    {
        List<LaboratorioListDto> GetLista();
        LaboratorioEditDto GetLaboratorioPorId(int? id);
        void Guardar(Laboratorio laboratorio);
        void Borrar(int? id);
        bool Existe(Laboratorio laboratorio);
    }
}
