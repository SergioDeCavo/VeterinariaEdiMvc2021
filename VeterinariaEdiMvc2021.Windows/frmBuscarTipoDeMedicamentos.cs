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
    public partial class frmBuscarTipoDeMedicamentos : Form
    {
        public frmBuscarTipoDeMedicamentos()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmBuscarTipoDeMedicamentos_Load(object sender, EventArgs e)
        {
            Helpers.Helper.CargarComboTipoDeMedicamentos(ref cboTipoDeMedicamento);
        }

        private TipoDeMedicamentoListDto tipoDeMedicamentoDto;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoDeMedicamentoDto = cboTipoDeMedicamento.SelectedItem as TipoDeMedicamentoListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboTipoDeMedicamento.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoDeMedicamento, "Debe seleccionar un Tipo de Medicamento");
            }
            return valido;
        }

        public TipoDeMedicamentoListDto GetTipoDeMedicamento()
        {
            return tipoDeMedicamentoDto;
        }
    }
}
