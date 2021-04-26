using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;

namespace VeterinariaEdiMvc2021.Entidades.DTOs.Provincia
{
    public class ProvinciaDetailsDto
    {
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }
        public List<Entidades.Localidad> Localidades { get; set; }
    }
}
