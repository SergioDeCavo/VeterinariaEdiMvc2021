using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.FormaFarmaceutica
{
    public class FormaFarmaceuticaListViewModel
    {
        public int FormaFarmaceuticaId { get; set; }

        [Display(Name = "Forma Farmacèutica")]
        public string Descripcion { get; set; }
    }
}
