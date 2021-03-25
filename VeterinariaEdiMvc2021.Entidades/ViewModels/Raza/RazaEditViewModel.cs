using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Raza
{
    public class RazaEditViewModel
    {
        public int RazaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Mascota")]
        [Range(1, int.MaxValue, ErrorMessage ="Debe Seleccionar un Tipo de Mascota")]
        public int TipoDeMascotaId { get; set; }

        public List<TipoDeMascotaListViewModel> TipoDeMascotas { get; set; }

        [Display(Name="Descripciòn")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(100, ErrorMessage ="El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength =3)]
        public string Descripcion { get; set; }

        

    }
}
