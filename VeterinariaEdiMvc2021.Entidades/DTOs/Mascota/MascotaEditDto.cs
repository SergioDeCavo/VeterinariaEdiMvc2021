using System;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Mascota
{
    public class MascotaEditDto
    {
        public int MascotaId { get; set; }

        public int TipoDeMascotaId { get; set; }

        public int RazaId { get; set; }

        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

    }
}
