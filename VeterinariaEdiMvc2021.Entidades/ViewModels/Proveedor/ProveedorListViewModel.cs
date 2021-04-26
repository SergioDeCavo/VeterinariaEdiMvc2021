using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Proveedor
{
    public class ProveedorListViewModel
    {
        public int ProveedorId { get; set; }

        [Display(Name="C.U.I.T")]
        public string CUIT { get; set; }

        [Display(Name = "Razòn Social")]
        public string RazonSocial { get; set; }

        [Display(Name = "Direcciòn")]
        public string Direccion { get; set; }

        [Display(Name = "Telèfono Mòvil")]
        public string TelefonoMovil { get; set; }

        public string Localidad { get; set; }
    }
}
