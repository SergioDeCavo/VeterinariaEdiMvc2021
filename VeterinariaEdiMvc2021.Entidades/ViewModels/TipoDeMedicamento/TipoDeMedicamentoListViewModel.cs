using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMedicamento
{
    public class TipoDeMedicamentoListViewModel
    {
        public int TipoDeMedicamentoId { get; set; }

        [Display(Name = "Descripciòn")]
        public string Descripcion { get; set; }
    }
}
