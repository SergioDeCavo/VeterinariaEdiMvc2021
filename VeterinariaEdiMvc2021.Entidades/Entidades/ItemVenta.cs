namespace VeterinariaEdiMvc2021.Entidades.Entidades
{
    public class ItemVenta
    {
        public int ItemVentaId { get; set; }
        public int VentaId { get; set; }
        public int MedicamentoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public Venta Venta { get; set; }
        public Medicamento Medicamento { get; set; }
    }
}
