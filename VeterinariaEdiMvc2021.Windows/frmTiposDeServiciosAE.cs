using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeServiciosAE : Form
    {
        public frmTiposDeServiciosAE()
        {
            InitializeComponent();
        }

        private TipoDeServicioEditDto tipoSerDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public TipoDeServicioEditDto GetTipoDeServicio()
        {
            return tipoSerDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoSerDto != null)
            {
                txtTipoDeServicio.Text = tipoSerDto.Descripcion;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoSerDto == null)
                {
                    tipoSerDto = new TipoDeServicioEditDto();
                }
                tipoSerDto.Descripcion = txtTipoDeServicio.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoDeServicio.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeServicio, "El nombre del Tipo de Servicio es requerido");

            }
            return valido;
        }

        public void SetTipo(TipoDeServicioEditDto tipoSerEditDto)
        {
            tipoSerDto = tipoSerEditDto;
        }
    }
}
