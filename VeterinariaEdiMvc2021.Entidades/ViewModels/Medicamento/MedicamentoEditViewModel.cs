using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaEdiMvc2021.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMedicamento;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento
{
    public class MedicamentoEditViewModel
    {
        public int MedicamentoId { get; set; }

        [Display(Name = "Nombre Comercial")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string NombreComercial { get; set; }

        [Display(Name = "Tipo de Medicamento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de Medicamento")]
        public int TipoDeMedicamentoId { get; set; }

        [Display(Name = "Forma Farmacèutica")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Forma Farmacèutica")]
        public int FormaFarmaceuticaId { get; set; }

        [Display(Name = "Laboratorio")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Laboratorio")]
        public int LaboratorioId { get; set; }

        [Display(Name = "Precio de Venta")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal PrecioVenta { get; set; }

        [Display(Name = "Unidades en Stock")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public int UnidadesEnStock { get; set; }

        [Display(Name = "Nivel de reposiciòn")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public int NivelDeReposicion { get; set; }

        [Display(Name = "Cantidades por Unidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public string CantidadesPorUnidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Suspendido { get; set; }

        public List<TipoDeMedicamentoListViewModel> TipoDeMedicamento { get; set; }
        public List<FormaFarmaceuticaListViewModel> FormaFarmaceutica { get; set; }
        public List<LaboratorioListViewModel>  Laboratorio { get; set; }
    }
}
