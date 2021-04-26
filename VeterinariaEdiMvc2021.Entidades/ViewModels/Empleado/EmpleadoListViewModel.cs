using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Empleado
{
    public class EmpleadoListViewModel
    {
        public int EmpleadoId { get; set; }

        public string Empleado { get { return $"{Apellido} {Nombre}"; } }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [Display(Name = "Tipo de Tarea")]
        public string TipoDeTarea { get; set; }

        [Display(Name = "Direcciòn")]
        public string Direccion { get; set; }

        [Display(Name = "Telèfono Mòvil")]
        public string TelefonoMovil { get; set; }

        public string Localidad { get; set; }
    }
}
