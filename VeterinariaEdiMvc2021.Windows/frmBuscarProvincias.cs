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
    public partial class frmBuscarProvincias : Form
    {
        public frmBuscarProvincias()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmBuscarProvincias_Load(object sender, EventArgs e)
        {
            Helpers.Helper.CargarComboProvincias(ref cboProvincia);
        }

        private ProvinciaListDto provinciaDto;

        public ProvinciaListDto GetProvincia()
        {
            return provinciaDto;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                provinciaDto = cboProvincia.SelectedItem as ProvinciaListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvincia, "Debe seleccionar una Provincia");
            }
            return valido;
        }

        
    }
}
