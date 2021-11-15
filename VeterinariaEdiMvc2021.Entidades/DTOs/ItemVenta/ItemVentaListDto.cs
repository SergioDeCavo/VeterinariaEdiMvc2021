namespace VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta
{
    public class ItemVentaListDto
    {
        public int ItemVentaId { get; set; }
        public int VentaId { get; set; }
        public string Medicamento { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
