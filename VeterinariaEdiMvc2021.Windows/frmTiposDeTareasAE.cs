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
    public partial class frmTiposDeTareasAE : Form
    {
        public frmTiposDeTareasAE()
        {
            InitializeComponent();
        }

        private TipoDeTareaEditDto tipoTarDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public TipoDeTareaEditDto GetTipoDeTarea()
        {
            return tipoTarDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoTarDto != null)
            {
                txtTipoDeTarea.Text = tipoTarDto.Descripcion;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoTarDto == null)
                {
                    tipoTarDto = new TipoDeTareaEditDto();
                }
                tipoTarDto.Descripcion = txtTipoDeTarea.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoDeTarea.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeTarea, "El nombre del Tipo de Tarea es requerido");

            }
            return valido;
        }

        public void SetTipo(TipoDeTareaEditDto tipoTarEditDto)
        {
            tipoTarDto = tipoTarEditDto;
        }
    }
}
