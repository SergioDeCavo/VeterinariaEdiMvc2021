using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota
{
    public class TipoDeMascotaEditViewModel
    {
        public int TipoDeMascotaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo{0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripciòn")]
        public string Descripcion { get; set; }
    }
}
