using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeTarea
{
    public class TipoDeTareaListViewModel
    {
        public int TipoDeTareaId { get; set; }

        [Display(Name="Descripciòn")]
        public string Descripcion { get; set; }
    }
}
