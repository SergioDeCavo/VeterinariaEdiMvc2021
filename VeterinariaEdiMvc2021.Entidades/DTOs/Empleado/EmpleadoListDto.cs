using System;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Empleado
{
    public class EmpleadoListDto:ICloneable
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDeTarea { get; set; }
        public string Direccion { get; set; }
        public string TelefonoMovil { get; set; }
        public string Localidad { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
