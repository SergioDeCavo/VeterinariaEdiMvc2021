using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeServicio
{
    public class TipoDeServicioListViewModel
    {
        public int TipoDeServicioId { get; set; }

        [Display(Name = "Descripciòn")]
        public string Descripcion { get; set; }
    }
}
