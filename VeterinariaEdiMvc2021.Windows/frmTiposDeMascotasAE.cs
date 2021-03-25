using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeMascotasAE : Form
    {
        public frmTiposDeMascotasAE()
        {
            InitializeComponent();
        }

        private TipoDeMascotaEditDto tipoMasDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public TipoDeMascotaEditDto GetTipoDeMascota()
        {
            return tipoMasDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoMasDto != null)
            {
                txtTipoDeMascota.Text = tipoMasDto.Descripcion;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoMasDto == null)
                {
                    tipoMasDto = new TipoDeMascotaEditDto();
                }
                tipoMasDto.Descripcion = txtTipoDeMascota.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoDeMascota.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeMascota, "El nombre del Tipo de Mascota es requerido");

            }
            return valido;
        }

        public void SetTipo(TipoDeMascotaEditDto tipoMasEditDto)
        {
            tipoMasDto = tipoMasEditDto;
        }
    }
}
