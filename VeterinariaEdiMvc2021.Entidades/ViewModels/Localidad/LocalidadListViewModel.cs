using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad
{
    public class LocalidadListViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = "Nombre de la Localidad")]
        public string NombreLocalidad { get; set; }


        public string Provincia { get; set; }
    }
}
