using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Droga
{
    public class DrogaListViewModel
    {
        public int DrogaId { get; set; }

        [Display(Name = "Nombre de la Droga")]
        public string NombreDroga { get; set; }
    }
}
