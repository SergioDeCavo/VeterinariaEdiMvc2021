using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Laboratorio
{
    public class LaboratorioEditViewModel
    {
        public int LaboratorioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo{0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre Laboratorio")]
        public string Nombre { get; set; }
    }
}
