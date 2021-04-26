using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Cliente;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Raza;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;

namespace VeterinariaEdiMvc2021.Entidades.ViewModels.Mascota
{
    public class MascotaEditViewModel
    {
        public int MascotaId { get; set; }

        [Display(Name = "Tipo de Mascota")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de Mascota")]
        public int TipoDeMascotaId { get; set; }

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Raza")]
        public int RazaId { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Nombre { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public List<TipoDeMascotaListViewModel> TipoDeMascota { get; set; }
        public List<RazaListViewModel> Raza { get; set; }
        public List<ClienteListViewModel> Cliente { get; set; }
    }
}
