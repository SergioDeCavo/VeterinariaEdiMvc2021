using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota
{
    public class TipoDeMascotaListViewModel
    {
        public int TipoDeMascotaId { get; set; }

        [Display(Name = "Descripciòn")]
        public string Descripcion { get; set; }
    }
}
