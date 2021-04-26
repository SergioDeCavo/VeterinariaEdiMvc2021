using System.Data.Entity.ModelConfiguration;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.EntityTypeConfigurations
{
    public class FormaFarmaceuticaEntityTypeConfiguration:EntityTypeConfiguration<FormaFarmaceutica>
    {
        public FormaFarmaceuticaEntityTypeConfiguration()
        {
            ToTable("FormasFarmaceuticas");
        }
    }
}
