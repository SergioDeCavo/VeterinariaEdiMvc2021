using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Carrito
{
    public class CarritoItemModel
    {
        public MedicamentoListViewModel Medicamento { get; set; }
        public int Cantidad { get; set; }

    }
}
