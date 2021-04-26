using System;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Empleado;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmEmpleadosAE : Form
    {
        public frmEmpleadosAE()
        {
            InitializeComponent();
        }

        private EmpleadoEditDto empleadoDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public EmpleadoEditDto GetEmpleado()
        {
            return empleadoDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.Helper.CargarComboTipoDeDocumentos(ref cboTipoDeDocumento);
            Helpers.Helper.CargarComboProvincias(ref cboProvincia);
            //Helpers.Helper.CargarComboLocalidades(ref cboLocalidad, null);
            Helpers.Helper.CargarComboTipoDeTareas(ref cboTipoDeTarea);
            if (empleadoDto == null)
            {
                return;
            }
            Helpers.Helper.CargarComboLocalidades(ref cboLocalidad, null);
            txtNombre.Text = empleadoDto.Nombre;
            txtApellido.Text = empleadoDto.Apellido;
            cboTipoDeDocumento.SelectedValue = empleadoDto.TipoDeDocumentoId;
            txtNumeroDocumento.Text = empleadoDto.NumeroDocumento;
            txtDireccion.Text = empleadoDto.Direccion;
            cboProvincia.SelectedValue = empleadoDto.ProvinciaId;
            cboLocalidad.SelectedValue = empleadoDto.LocalidadId;
            txtTelefonoFijo.Text = empleadoDto.TelefonoFijo;
            txtTelefonoMovil.Text = empleadoDto.TelefonoMovil;
            txtCorreoElectronico.Text = empleadoDto.CorreoElectronico;
            cboTipoDeTarea.SelectedValue = empleadoDto.TipoDeTareaId;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (empleadoDto == null)
                {
                    empleadoDto = new EmpleadoEditDto();
                }
                empleadoDto.Nombre = txtNombre.Text;
                empleadoDto.Apellido = txtApellido.Text;
                empleadoDto.TipoDeDocumentoId = ((TipoDeDocumentoListDto)cboTipoDeDocumento.SelectedItem).TipoDeDocumentoId;
                empleadoDto.NumeroDocumento = txtNumeroDocumento.Text;
                empleadoDto.Direccion = txtDireccion.Text;
                empleadoDto.ProvinciaId = ((ProvinciaListDto)cboProvincia.SelectedItem).ProvinciaId;
                empleadoDto.LocalidadId = ((LocalidadListDto)cboLocalidad.SelectedItem).LocalidadId;
                empleadoDto.TelefonoFijo = txtTelefonoFijo.Text;
                empleadoDto.TelefonoMovil = txtTelefonoMovil.Text;
                empleadoDto.CorreoElectronico = txtCorreoElectronico.Text;
                empleadoDto.TipoDeTareaId = ((TipoDeTareaListDto)cboTipoDeTarea.SelectedItem).TipoDeTareaId;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            return valido;
        }

        public void SetEmpleado(EmpleadoEditDto empleadoEditDto)
        {
            empleadoDto = empleadoEditDto;
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
