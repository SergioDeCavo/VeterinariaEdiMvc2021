using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmFormasFarmaceuticasAE : Form
    {
        public frmFormasFarmaceuticasAE()
        {
            InitializeComponent();
        }

        private FormaFarmaceuticaEditDto formaDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (formaDto == null)
                {
                    formaDto = new FormaFarmaceuticaEditDto();
                }
                formaDto.Descripcion = txtFormaFarmaceutica.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtFormaFarmaceutica.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtFormaFarmaceutica, "El nombre de la Forma Farmacèutica es requerida");

            }
            return valido;
        }

        public FormaFarmaceuticaEditDto GetForma()
        {
            return formaDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (formaDto != null)
            {
                txtFormaFarmaceutica.Text = formaDto.Descripcion;
            }
        }

        public void SetTipo(FormaFarmaceuticaEditDto formaEditDto)
        {
            formaDto = formaEditDto;
        }
    }
}
