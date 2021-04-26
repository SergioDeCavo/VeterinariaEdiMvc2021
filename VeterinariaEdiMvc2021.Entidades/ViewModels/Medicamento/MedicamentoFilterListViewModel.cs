using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMedicamento;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento
{
    public class MedicamentoFilterListViewModel
    {
        public List<MedicamentoListViewModel> Medicamento { get; set; }
        public List<TipoDeMedicamentoListViewModel> TipoDeMedicamento { get; set; }
    }
}
