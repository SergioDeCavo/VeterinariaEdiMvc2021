using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Carrito
{
    public class CarritoModel
    {
        private List<CarritoItemModel> items = new List<CarritoItemModel>();

        public IEnumerable<CarritoItemModel> Items
        {
            get { return items; }
        }

        public void AddItem(MedicamentoListViewModel medicamento, int cantidad)
        {
            CarritoItemModel item =
                items.SingleOrDefault(p => p.Medicamento.MedicamentoId == medicamento.MedicamentoId);

            if (item == null)
            {
                items.Add(new CarritoItemModel
                {
                    Medicamento = medicamento,
                    Cantidad = cantidad
                });
            }
            else
            {
                item.Cantidad += cantidad;
            }
        }

        public void RemoveItem(int medicamentoId)
        {
            items.RemoveAll(l => l.Medicamento.MedicamentoId == medicamentoId);
        }

        public decimal GetCartTotal()
        {
            return items.Sum(e => e.Medicamento.PrecioVenta * e.Cantidad);

        }
        public void Clear()
        {
            items.Clear();
        }

    }
}
