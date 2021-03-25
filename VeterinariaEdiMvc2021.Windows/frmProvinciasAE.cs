using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmProvinciasAE : Form
    {
        public frmProvinciasAE()
        {
            InitializeComponent();
        }

        private ProvinciaEditDto provinciaDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public ProvinciaEditDto GetProvincia()
        {
            return provinciaDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provinciaDto != null)
            {
                txtProvincia.Text = provinciaDto.NombreProvincia;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provinciaDto == null)
                {
                    provinciaDto = new ProvinciaEditDto();
                }
                provinciaDto.NombreProvincia = txtProvincia.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProvincia.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtProvincia, "El nombre de la Provincia es requerida");

            }
            return valido;
        }

        public void SetTipo(ProvinciaEditDto provinciaEditDto)
        {
            provinciaDto = provinciaEditDto;
        }
    }
}
