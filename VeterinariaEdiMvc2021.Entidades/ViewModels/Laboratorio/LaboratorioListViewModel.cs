using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Laboratorio
{
    public class LaboratorioListViewModel
    {
        public int LaboratorioId { get; set; }

        [Display(Name = "Nombre Laboratorio")]
        public string Nombre { get; set; }
    }
}
