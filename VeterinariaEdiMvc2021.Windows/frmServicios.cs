using System;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmServicios : Form
    {
        private static frmServicios instancia;
        public static frmServicios GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmServicios();
                instancia.FormClosed += Form_Closed;
            }
            return instancia;
        }

        private static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
        public frmServicios()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            frmCompras frm = DI.Create<frmCompras>();
            frm.ShowDialog(this);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas frm = DI.Create<frmVentas>();
            frm.ShowDialog(this);
        }

        private void btnServicios2_Click(object sender, EventArgs e)
        {
            frmServicios2 frm = DI.Create<frmServicios2>();
            frm.ShowDialog(this);
        }
    }
    
}
