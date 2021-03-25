using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmLaboratoriosAE : Form
    {
        public frmLaboratoriosAE()
        {
            InitializeComponent();
        }

        private LaboratorioEditDto laboratorioDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public LaboratorioEditDto GetLaboratorio()
        {
            return laboratorioDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (laboratorioDto != null)
            {
                txtLaboratorio.Text = laboratorioDto.Nombre;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (laboratorioDto == null)
                {
                    laboratorioDto = new LaboratorioEditDto();
                }
                laboratorioDto.Nombre = txtLaboratorio.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtLaboratorio.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtLaboratorio, "El nombre del Laboratorio es requerido");

            }
            return valido;
        }

        public void SetTipo(LaboratorioEditDto laboratorioEditDto)
        {
            laboratorioDto = laboratorioEditDto;
        }
    }
}
