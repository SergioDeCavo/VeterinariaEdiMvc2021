using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeDocumento
{
    public class TipoDeDocumentoListViewModel
    {
        public int TipoDeDocumentoId { get; set; }

        [Display(Name = "Descripciòn")]
        public string Descripcion { get; set; }

    }
}
