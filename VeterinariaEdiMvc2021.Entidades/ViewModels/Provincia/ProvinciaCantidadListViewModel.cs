using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia
{
    public class ProvinciaCantidadListViewModel
    {
        public int ProvinciaId { get; set; }

        [Display(Name = "Nombre Provincia")]
        public string NombreProvincia { get; set; }

        [Display(Name="Cant. de Localidades")]
        public int CantidadProvincias{ get; set; }
    }
}
