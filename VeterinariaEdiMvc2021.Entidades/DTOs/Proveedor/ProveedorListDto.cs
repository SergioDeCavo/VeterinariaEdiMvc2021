using System;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor
{
    public class ProveedorListDto:ICloneable
    {
        public int ProveedorId { get; set; }
        public string CUIT { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string TelefonoMovil { get; set; }
        public string Localidad { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
