using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            frmServicios frm = DI.Create<frmServicios>();
            frm.ShowDialog(this);
        }

        private void btnArchivos_Click(object sender, EventArgs e)
        {
            frmArchivos frm = DI.Create<frmArchivos>();
            frm.ShowDialog(this);
        }

        private void btnMedicinas_Click(object sender, EventArgs e)
        {
            frmMedicinas frm = DI.Create<frmMedicinas>();
            frm.ShowDialog(this);
        }

        private void btnMascotas_Click(object sender, EventArgs e)
        {
            frmMascotas frm = DI.Create<frmMascotas>();
            frm.ShowDialog(this);

        }
    }
}
