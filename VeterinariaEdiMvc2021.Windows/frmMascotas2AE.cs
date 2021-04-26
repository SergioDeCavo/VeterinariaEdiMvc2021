using System;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.DTOs.Mascota;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmMascotas2AE : Form
    {
        public frmMascotas2AE()
        {
            InitializeComponent();
        }

        private MascotaEditDto mascotaDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public MascotaEditDto GetMascota()
        {
            return mascotaDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.Helper.CargarComboTiposDeMascota(ref cboTipoDeMascota);
            Helpers.Helper.CargarComboRazas(ref cboRaza);
            Helpers.Helper.CargarComboClientes(ref cboCliente, null);

            if (mascotaDto == null)
            {
                return;
            }

            cboTipoDeMascota.SelectedValue = mascotaDto.TipoDeMascotaId;
            cboRaza.SelectedValue = mascotaDto.RazaId;
            cboCliente.SelectedValue = mascotaDto.ClienteId;
            txtNombre.Text = mascotaDto.Nombre;
            dtpFechaDeNacimiento.Text = (mascotaDto.FechaDeNacimiento).ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (mascotaDto == null)
                {
                    mascotaDto = new MascotaEditDto();
                }
                mascotaDto.TipoDeMascotaId = ((TipoDeMascotaListDto)cboTipoDeMascota.SelectedItem).TipoDeMascotaId;
                mascotaDto.RazaId = ((RazaListDto)cboRaza.SelectedItem).RazaId;
                mascotaDto.ClienteId = ((ClienteListDto)cboCliente.SelectedItem).ClienteId;
                mascotaDto.Nombre = txtNombre.Text;
                mascotaDto.FechaDeNacimiento = dtpFechaDeNacimiento.Value;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            return valido;
        }

        public void SetMascota(MascotaEditDto mascotaEditDto)
        {
            mascotaDto = mascotaEditDto;
        }
    }
}
