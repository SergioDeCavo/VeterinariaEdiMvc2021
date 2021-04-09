using System;
using System.Windows.Forms;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows.Helpers
{
    public class Helper
    {
        public static void CargarComboTiposDeMascota(ref ComboBox combo) 
        {
            IServiciosTipoDeMascota serviciosTipoDeMascota = DI.Create<IServiciosTipoDeMascota>();
            var lista = serviciosTipoDeMascota.GetLista();
            var defaultTipoDeMascota = new TipoDeMascotaListDto
            {
                TipoDeMascotaId = 0,
                Descripcion = "<Seleccione un Tipo de Mascota>"
            };
            lista.Insert(0, defaultTipoDeMascota);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDeMascotaId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;

        }

        public static void CargarComboProvincias(ref ComboBox combo)
        {
            IServiciosProvincia serviciosProvincia = DI.Create<IServiciosProvincia>();
            var lista = serviciosProvincia.GetLista();
            var defaultProvincia = new ProvinciaListDto
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccione una Provincia>"
            };
            lista.Insert(0, defaultProvincia);
            combo.DataSource = lista;
            combo.ValueMember = "ProvinciaId";
            combo.DisplayMember = "NombreProvincia";
            combo.SelectedIndex = 0;

        }
    }
}
