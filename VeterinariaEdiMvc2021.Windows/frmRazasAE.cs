using System;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmRazasAE : Form
    {
        public frmRazasAE()
        {
            InitializeComponent();
        }

        private RazaEditDto razaDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public RazaEditDto GetRaza()
        {
            return razaDto;
        }

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            Helpers.Helper.CargarComboTiposDeMascota(ref cboTipoDeMascota);
            if (razaDto == null)
            {
                return;
            }
            txtRaza.Text = razaDto.Descripcion;
            cboTipoDeMascota.SelectedValue = razaDto.TipoDeMascotaId;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidadDatos())
            {
                if (razaDto == null)
                {
                    razaDto = new RazaEditDto();
                }
                razaDto.TipoDeMascotaId = ((TipoDeMascotaListDto)cboTipoDeMascota.SelectedItem).TipoDeMascotaId;
                razaDto.Descripcion= txtRaza.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidadDatos()
        {
            bool valido = true;
            return valido;
        }

        public void SetRaza(RazaEditDto razaEditDto)
        {
            razaDto = razaEditDto;
        }
    }
}
