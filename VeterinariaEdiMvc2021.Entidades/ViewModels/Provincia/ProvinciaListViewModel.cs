using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia
{
    public class ProvinciaListViewModel
    {
        public int ProvinciaId { get; set; }

        [Display(Name = "Nombre Provincia")]
        public string NombreProvincia { get; set; }
    }
}
