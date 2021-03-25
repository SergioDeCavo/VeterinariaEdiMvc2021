using System.Data.Entity.ModelConfiguration;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.EntityTypeConfigurations
{
    class LaboratorioEntityTypeConfiguration:EntityTypeConfiguration<Laboratorio>
    {
        public LaboratorioEntityTypeConfiguration()
        {
            ToTable("Laboratorios");
        }
    }
}
