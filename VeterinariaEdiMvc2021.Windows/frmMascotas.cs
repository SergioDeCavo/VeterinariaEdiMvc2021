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
    public partial class frmMascotas : Form
    {
        private static frmMascotas instancia;
        public static frmMascotas GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmMascotas();
                instancia.FormClosed += Form_Closed;
            }
            return instancia;
        }

        private static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
        public frmMascotas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMascotas2_Click(object sender, EventArgs e)
        {
            frmMascotas2 frm = DI.Create<frmMascotas2>();
            frm.ShowDialog(this);
        }

        private void btnTiposDeMascotas_Click(object sender, EventArgs e)
        {
            frmTiposDeMascotas frm = DI.Create<frmTiposDeMascotas>();
            frm.ShowDialog(this);
        }

        private void btnRazas_Click(object sender, EventArgs e)
        {
            frmRazas frm = DI.Create<frmRazas>();
            frm.ShowDialog(this);
        }
    }
}
