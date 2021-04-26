using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia
{
    public class ProvinciaDetailsViewModel
    {
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }
        public List<LocalidadListViewModel> Localidades { get; set; }
    }
}
