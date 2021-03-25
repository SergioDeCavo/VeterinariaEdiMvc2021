using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Raza
{
    public class RazaListViewModel
    {
        public int RazaId { get; set; }

        [Display(Name = "Tipo de Mascota")]
        public string TipoDeMascota { get; set; }

        [Display(Name = "Descripciòn")]
        public string Descripcion { get; set; }
    }

}
