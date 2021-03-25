using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos
{
    public class VeterinariaEdiMvc2021DbContext:DbContext
    {
        public VeterinariaEdiMvc2021DbContext():base("MiConexion")
        {
            Database.CommandTimeout = 50;
            Configuration.UseDatabaseNullSemantics = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<VeterinariaEdiMvc2021DbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Droga> Drogas { get; set; }
        public DbSet<FormaFarmaceutica> FormaFarmaceuticas { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<TipoDeDocumento> TipoDeDocumentos { get; set; }
        public DbSet<TipoDeMascota> TipoDeMascotas { get; set; }
        public DbSet<TipoDeMedicamento> TipoDeMedicamentos { get; set; }
        public DbSet<TipoDeServicio> TipoDeServicios { get; set; }
        public DbSet<TipoDeTarea> TipoDeTareas { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Raza> Razas { get; set; }
    }
}
