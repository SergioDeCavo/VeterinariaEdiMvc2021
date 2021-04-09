using System;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmBuscarTiposDeMascota : Form
    {

        public frmBuscarTiposDeMascota()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmBuscarTiposDeMascota_Load(object sender, EventArgs e)
        {
            Helpers.Helper.CargarComboTiposDeMascota(ref cboTipoDeMascota);
        }

        private TipoDeMascotaListDto tipoDeMascotaDto;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoDeMascotaDto = cboTipoDeMascota.SelectedItem as TipoDeMascotaListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboTipoDeMascota.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoDeMascota, "Debe seleccionar un Tipo de Mascota");
            }
            return valido;
        }

        public TipoDeMascotaListDto GetTipoDeMascota()
        {
            return tipoDeMascotaDto;
        }
    }
}
