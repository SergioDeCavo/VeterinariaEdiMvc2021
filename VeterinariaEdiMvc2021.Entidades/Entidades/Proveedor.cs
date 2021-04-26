namespace VeterinariaEdiMvc2021.Entidades.Entidades
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string CUIT { get; set; }
        public string RazonSocial { get; set; }
        public string PersonaDeContacto { get; set; }
        public string Direccion { get; set; }
        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public Localidad Localidad { get; set; }
        public Provincia Provincia { get; set; }
    }
}
