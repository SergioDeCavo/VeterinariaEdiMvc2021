using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeMedicamentosAE : Form
    {
        public frmTiposDeMedicamentosAE()
        {
            InitializeComponent();
        }

        private TipoDeMedicamentoEditDto tipoMedDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public TipoDeMedicamentoEditDto GetTipoDeMedicamento()
        {
            return tipoMedDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoMedDto != null)
            {
                txtTipoDeMedicamento.Text = tipoMedDto.Descripcion;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoMedDto == null)
                {
                    tipoMedDto = new TipoDeMedicamentoEditDto();
                }
                tipoMedDto.Descripcion = txtTipoDeMedicamento.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoDeMedicamento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeMedicamento, "El nombre del Tipo de Medicamento es requerido");

            }
            return valido;
        }

        public void SetTipo(TipoDeMedicamentoEditDto tipoMedEditDto)
        {
            tipoMedDto = tipoMedEditDto;
        }
    }
}
