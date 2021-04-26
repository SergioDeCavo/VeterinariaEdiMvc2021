using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmBuscarLocalidades : Form
    {
        public frmBuscarLocalidades()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmBuscarLocalidades_Load(object sender, EventArgs e)
        {
            Helpers.Helper.CargarComboLocalidades(ref cboLocalidad, null);
        }

        private LocalidadListDto localidadDto;

        public LocalidadListDto GetLocalidad()
        {
            return localidadDto;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                localidadDto = cboLocalidad.SelectedItem as LocalidadListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboLocalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboLocalidad, "Debe seleccionar una Localidad");
            }
            return valido;
        }
    }
}
