using System;
using System.Windows.Forms;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmClientesAE : Form
    {
        public frmClientesAE()
        {
            InitializeComponent();
        }

        private ClienteEditDto clienteDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public ClienteEditDto GetCliente()
        {
            return clienteDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.Helper.CargarComboTipoDeDocumentos(ref cboTipoDeDocumento);
            Helpers.Helper.CargarComboProvincias(ref cboProvincia);

            if (clienteDto==null)
            {
                return;
            }

            Helpers.Helper.CargarComboLocalidades(ref cboLocalidad, null);
            txtNombre.Text = clienteDto.Nombre;
            txtApellido.Text = clienteDto.Apellido;
            cboTipoDeDocumento.SelectedValue = clienteDto.TipoDeDocumentoId;
            txtNumeroDocumento.Text = clienteDto.NumeroDocumento;
            txtDireccion.Text = clienteDto.Direccion;
            cboProvincia.SelectedValue = clienteDto.ProvinciaId;
            cboLocalidad.SelectedValue = clienteDto.LocalidadId;
            txtTelefonoFijo.Text = clienteDto.TelefonoFijo;
            txtTelefonoMovil.Text = clienteDto.TelefonoMovil;
            txtCorreoElectronico.Text = clienteDto.CorreoElectronico;
        }

        private void frmClientesAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (clienteDto==null)
                {
                    clienteDto = new ClienteEditDto();
                }
                clienteDto.Nombre = txtNombre.Text;
                clienteDto.Apellido = txtApellido.Text;
                clienteDto.TipoDeDocumentoId = ((TipoDeDocumentoListDto)cboTipoDeDocumento.SelectedItem).TipoDeDocumentoId;
                clienteDto.NumeroDocumento = txtNumeroDocumento.Text;
                clienteDto.Direccion = txtDireccion.Text;
                clienteDto.ProvinciaId = ((ProvinciaListDto)cboProvincia.SelectedItem).ProvinciaId;
                clienteDto.LocalidadId = ((LocalidadListDto)cboLocalidad.SelectedItem).LocalidadId;
                clienteDto.TelefonoFijo = txtTelefonoFijo.Text;
                clienteDto.TelefonoMovil = txtTelefonoMovil.Text;
                clienteDto.CorreoElectronico = txtCorreoElectronico.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            return valido;
        }

        public void SetCliente(ClienteEditDto clienteEditDto)
        {
            clienteDto = clienteEditDto;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex>0)
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
