using System.Data.Entity.ModelConfiguration;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.EntityTypeConfigurations
{
    public class TipoDeTareaEntityTypeConfiguration:EntityTypeConfiguration<TipoDeTarea>
    {
        public TipoDeTareaEntityTypeConfiguration()
        {
            ToTable("TiposDeTareas");
        }
    }
}
