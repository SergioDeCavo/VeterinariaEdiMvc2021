using System.Data.Entity.ModelConfiguration;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.EntityTypeConfigurations
{
    class TipoDeServicioEntityTypeConfiguration:EntityTypeConfiguration<TipoDeServicio>
    {
        public TipoDeServicioEntityTypeConfiguration()
        {
            ToTable("TiposDeServicios");
        }
    }
}
