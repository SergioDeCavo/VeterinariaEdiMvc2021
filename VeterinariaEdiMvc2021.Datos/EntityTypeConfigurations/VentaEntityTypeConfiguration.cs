using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.EntityTypeConfigurations
{
    public class VentaEntityTypeConfiguration:EntityTypeConfiguration<Venta>
    {
        public VentaEntityTypeConfiguration()
        {
            ToTable("Ventas");
        }
    }
}
