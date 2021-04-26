using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento
{
    public class MedicamentoListViewModel
    {
        public int MedicamentoId { get; set; }

        [Display(Name = "Nombre Comercial")]
        public string NombreComercial { get; set; }

        [Display(Name = "Tipo de Medicamento")]
        public string TipoDeMedicamento { get; set; }

        [Display(Name = "Forma Farmacèutica")]
        public string FormaFarmaceutica { get; set; }


        public string Laboratorio { get; set; }

        [Display(Name = "Precio de Venta")]
        public decimal PrecioVenta { get; set; }

        public bool Suspendido { get; set; }
    }
}
