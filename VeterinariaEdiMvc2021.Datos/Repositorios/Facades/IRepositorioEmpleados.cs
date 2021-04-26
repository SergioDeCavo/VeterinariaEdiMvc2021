using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Empleado;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioEmpleados
    {
        List<EmpleadoListDto> GetLista(string nombreTarea);
        bool Existe(Empleado empleado);
        void Guardar(Empleado empleado);
        EmpleadoEditDto GetEmpleadoPorId(int? id);
        void Borrar(int empleadoId);
    }
}
