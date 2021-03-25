using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmDrogasAE : Form
    {
        public frmDrogasAE()
        {
            InitializeComponent();
        }

        private DrogaEditDto drogaDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public DrogaEditDto GetDroga()
        {
            return drogaDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (drogaDto!=null)
            {
                txtDroga.Text = drogaDto.NombreDroga;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (drogaDto==null)
                {
                    drogaDto = new DrogaEditDto();
                }
                drogaDto.NombreDroga = txtDroga.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDroga.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDroga, "El nombre de la Droga es requerida");

            }
            return valido;
        }

        public void SetTipo(DrogaEditDto drogaEditDto)
        {
            drogaDto = drogaEditDto;
        }
    }
}
