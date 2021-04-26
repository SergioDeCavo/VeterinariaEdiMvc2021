using System;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmProveedoresAE : Form
    {
        public frmProveedoresAE()
        {
            InitializeComponent();
        }

        private ProveedorEditDto proveedorDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public ProveedorEditDto GetProveedor()
        {
            return proveedorDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.Helper.CargarComboProvincias(ref cboProvincia);
            //Helpers.Helper.CargarComboLocalidades(ref cboLocalidad, null);

            if (proveedorDto == null)
            {
                return;
            }
            Helpers.Helper.CargarComboLocalidades(ref cboLocalidad, null);
            txtCUIT.Text = proveedorDto.CUIT;
            txtRazonSocial.Text = proveedorDto.RazonSocial;
            txtPersonaDeContacto.Text = proveedorDto.PersonaDeContacto;
            txtDireccion.Text = proveedorDto.Direccion;
            cboProvincia.SelectedValue = proveedorDto.ProvinciaId;
            cboLocalidad.SelectedValue = proveedorDto.LocalidadId;
            txtTelefonoFijo.Text = proveedorDto.TelefonoFijo;
            txtTelefonoMovil.Text = proveedorDto.TelefonoMovil;
            txtCorreoElectronico.Text = proveedorDto.CorreoElectronico;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedorDto == null)
                {
                    proveedorDto = new ProveedorEditDto();
                }
                proveedorDto.CUIT = txtCUIT.Text;
                proveedorDto.RazonSocial = txtRazonSocial.Text;
                proveedorDto.PersonaDeContacto = txtPersonaDeContacto.Text;
                proveedorDto.Direccion = txtDireccion.Text;
                proveedorDto.ProvinciaId = ((ProvinciaListDto)cboProvincia.SelectedItem).ProvinciaId;
                proveedorDto.LocalidadId = ((LocalidadListDto)cboLocalidad.SelectedItem).LocalidadId;
                proveedorDto.TelefonoFijo = txtTelefonoFijo.Text;
                proveedorDto.TelefonoMovil = txtTelefonoMovil.Text;
                proveedorDto.CorreoElectronico = txtCorreoElectronico.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            return valido;
        }

        public void SetProveedor(ProveedorEditDto proveedorEditDto)
        {
            proveedorDto = proveedorEditDto;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex > 0)
            {
                var provincia = (ProvinciaListDto)cboProvincia.SelectedItem;
                Helpers.Helper.CargarComboLocalidades(ref cboLocalidad, provincia.NombreProvincia);
            }
            else
            {
                cboLocalidad.DataSource = null;
            }
        }
    }
}
