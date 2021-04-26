using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Cliente
{
    public class ClienteListViewModel
    {
        public int ClienteId { get; set; }
        public string Cliente { get { return $"{Apellido} {Nombre}"; } }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name="Direcciòn")]
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }

        [Display(Name="Telèfono Fijo")]
        public string TelefonoFijo { get; set; }

        [Display(Name = "Telèfono Mòvil")]
        public string TelefonoMovil { get; set; }

        [Display(Name = "Correo Electrònico")]
        public string CorreoElectronico { get; set; }

    }
}
