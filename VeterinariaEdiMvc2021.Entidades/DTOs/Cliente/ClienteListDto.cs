using System;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Cliente
{
    public class ClienteListDto:ICloneable
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
