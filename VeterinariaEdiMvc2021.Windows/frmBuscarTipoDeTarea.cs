using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmBuscarTipoDeTarea : Form
    {
        public frmBuscarTipoDeTarea()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmBuscarTipoDeTarea_Load(object sender, EventArgs e)
        {
            Helpers.Helper.CargarComboTipoDeTareas(ref cboTipoDeTarea);
        }

        private TipoDeTareaListDto tipoDeTareaDto;

        public TipoDeTareaListDto GetTipoDeTarea()
        {
            return tipoDeTareaDto;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoDeTareaDto = cboTipoDeTarea.SelectedItem as TipoDeTareaListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboTipoDeTarea.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoDeTarea, "Debe seleccionar un Tipo de Tarea");
            }
            return valido;
        }
    }
}
