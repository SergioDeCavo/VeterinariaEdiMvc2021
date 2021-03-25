using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeDocumento
{
    public class TipoDeDocumentoEditViewModel
    {
        public int TipoDeDocumentoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, ErrorMessage = "El campo{0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripciòn")]
        public string Descripcion { get; set; }
    }
}
