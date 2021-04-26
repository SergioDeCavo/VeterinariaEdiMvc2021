using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Empleado;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosEmpleado
    {
        List<EmpleadoListDto> GetLista(string nombreTarea);
        bool Existe(EmpleadoEditDto empleadoEditDto);
        void Guardar(EmpleadoEditDto empleadoDto);
        EmpleadoEditDto GetEmpleadoPorId(int? id);
        void Borrar(int empleadoId);
    }
}
