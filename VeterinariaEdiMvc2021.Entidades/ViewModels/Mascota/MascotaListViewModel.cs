using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Mascota
{
    public class MascotaListViewModel
    {
        public int MascotaId { get; set; }

        public string Nombre { get; set; }

        [Display(Name = "Tipo de Mascota")]
        public string TipoDeMascota { get; set; }

        public string Raza { get; set; }

        public string Cliente { get; set; }
    }
}
