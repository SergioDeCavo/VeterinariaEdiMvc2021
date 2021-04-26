using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Proveedor
{
    public class ProveedorEditViewModel
    {
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(13, ErrorMessage = "El campo {0} debe contener {1} caracteres")]
        public string CUIT { get; set; }

        [Display(Name = "Razòn Social")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string RazonSocial { get; set; }

        [Display(Name = "Persona de Contacto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string PersonaDeContacto { get; set; }

        [Display(Name = "Direcciòn")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Direccion { get; set; }

        [Display(Name = "Localidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Localidad")]
        public int LocalidadId { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Provincia")]
        public int ProvinciaId { get; set; }

        [Display(Name = "Telèfono Fijo")]
        public string TelefonoFijo { get; set; }

        [Display(Name = "Telèfono Mòvil")]
        public string TelefonoMovil { get; set; }

        [Display(Name = "Correo Electrònico")]
        public string CorreoElectronico { get; set; }

        public List<LocalidadListViewModel> Localidad { get; set; }
        public List<ProvinciaListViewModel> Provincia { get; set; }
    }
}
