using System.Collections.Generic;
using System.Linq;

namespace VeterinariaEdiMvc2021.Entidades.Entidades
{
    public class Carrito
    {
        public List<ItemCarrito> listaItems { get; set; } = new List<ItemCarrito>();

        public void AgregarAlCarrito(Medicamento medicamento, int cantidad)
        {
            var item = listaItems.SingleOrDefault(li => li.Medicamento.MedicamentoId == medicamento.MedicamentoId);
            if (item==null)
            {
                listaItems.Add(new ItemCarrito
                {
                    Medicamento = medicamento,
                    Cantidad = 1
                });
            }
            else
            {
                item.Cantidad++;
            }
        } 

        public void EliminarDelCarrito(Medicamento medicamento)
        {
            listaItems.RemoveAll(li => li.Medicamento.MedicamentoId == medicamento.MedicamentoId);
        }

        public List<ItemCarrito> GetItems()
        {
            return listaItems;
        }

        public void VaciarCarrito()
        {
            listaItems.Clear();
        }

        public decimal TotalCarrito()
        {
            return listaItems.Sum(li => li.Cantidad * li.Medicamento.PrecioVenta);
        }
    }
}
