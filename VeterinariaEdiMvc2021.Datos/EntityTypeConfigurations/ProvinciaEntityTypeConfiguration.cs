using System.Data.Entity.ModelConfiguration;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.EntityTypeConfigurations
{
    public class ProvinciaEntityTypeConfiguration:EntityTypeConfiguration<Provincia>
    {
        public ProvinciaEntityTypeConfiguration()
        {
            ToTable("Provincias");
        }
    }
}
