using System.Data.Entity.ModelConfiguration;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.EntityTypeConfiguration
{
    public class EmpleadoEntityTypeConfiguration:EntityTypeConfiguration<Empleado>
    {
        public EmpleadoEntityTypeConfiguration()
        {
            ToTable("Empleados");
        }
    }
}
