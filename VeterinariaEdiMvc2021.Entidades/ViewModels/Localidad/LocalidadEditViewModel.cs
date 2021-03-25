using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad
{
    public class LocalidadEditViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = "Nombre de la Localidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreLocalidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe Seleccionar una Provincia")]
        public int ProvinciaId { get; set; }

        public List<ProvinciaListViewModel> Provincias { get; set; }
    }
}
