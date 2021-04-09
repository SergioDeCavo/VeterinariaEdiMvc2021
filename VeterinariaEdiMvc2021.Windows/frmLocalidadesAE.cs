using System;
using System.Windows.Forms;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmLocalidadesAE : Form
    {
        public frmLocalidadesAE()
        {
            InitializeComponent();
        }

        private LocalidadEditDto localidadDto;

        public LocalidadEditDto GetLocalidad()
        {
            return localidadDto;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.Helper.CargarComboProvincias(ref cboProvincia);
            if (localidadDto==null)
            {
                return;
            }
            txtLocalidad.Text = localidadDto.NombreLocalidad;
            cboProvincia.SelectedValue = localidadDto.ProvinciaId;
        }

        private void frmLocalidadesAE_Load(object sender, EventArgs e)
        {
            

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidadDatos())
            {
                if (localidadDto==null)
                {
                    localidadDto = new LocalidadEditDto();
                }
                localidadDto.ProvinciaId = ((ProvinciaListDto)cboProvincia.SelectedItem).ProvinciaId;
                localidadDto.NombreLocalidad = txtLocalidad.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidadDatos()
        {
            bool valido = true;
            return valido;
        }

        public void SetLocalidad(LocalidadEditDto localidadEditDto)
        {
            localidadDto = localidadEditDto;
        }
    }
}
