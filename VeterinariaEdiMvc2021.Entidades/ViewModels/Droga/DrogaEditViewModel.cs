using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Droga
{
    public class DrogaEditViewModel
    {
        public int DrogaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo{0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre de la Droga")]
        public string NombreDroga { get; set; }

    }
}
