using System;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Raza
{
    public class RazaListDto:ICloneable
    {
        public int RazaId { get; set; }
        public string TipoDeMascota { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
