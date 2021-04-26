using VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Carrito
{
    public class ItemCarritoListViewModel
    {
        public MedicamentoListViewModel MedicamentoListViewModel { get; set; }
        public int Cantidad { get; set; }
    }
}
