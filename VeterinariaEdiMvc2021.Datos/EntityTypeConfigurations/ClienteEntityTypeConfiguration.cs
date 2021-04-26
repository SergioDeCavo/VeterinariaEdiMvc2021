using System.Data.Entity.ModelConfiguration;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.EntityTypeConfigurations
{
    public class ClienteEntityTypeConfiguration:EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityTypeConfiguration()
        {
            ToTable("Clientes");
        }
    }
}
