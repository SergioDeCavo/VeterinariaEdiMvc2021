using System;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Venta
{
    public class VentaListViewModel
    {
        public int VentaId { get; set; }

        [Display(Name = "Fecha de la Venta")]
        public DateTime FechaVenta { get; set; }


        public string Cliente { get; set; }


        public bool Anulado { get; set; }

    }
}
