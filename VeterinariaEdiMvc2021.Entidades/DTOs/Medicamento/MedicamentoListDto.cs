using System;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento
{
    public class MedicamentoListDto:ICloneable
    {
        public int MedicamentoId { get; set; }
        public string NombreComercial { get; set; }
        public string TipoDeMedicamento { get; set; }
        public string FormaFarmaceutica { get; set; }
        public string Laboratorio { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Suspendido { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
