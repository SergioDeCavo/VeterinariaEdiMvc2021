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
    public partial class frmMedicinas : Form
    {
        private static frmMedicinas instancia;
        public static frmMedicinas GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmMedicinas();
                instancia.FormClosed += Form_Closed;
            }
            return instancia;
        }

        private static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
        public frmMedicinas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            frmMedicamentos frm = DI.Create<frmMedicamentos>();
            frm.ShowDialog(this);
        }

        private void btnTiposDeMedicamentos_Click(object sender, EventArgs e)
        {
            frmTiposDeMedicamentos frm = DI.Create<frmTiposDeMedicamentos>();
            frm.ShowDialog(this);
        }

        private void btnDrogas_Click(object sender, EventArgs e)
        {
            frmDrogas frm = DI.Create<frmDrogas>();
            frm.ShowDialog(this);
        }

        private void btnLaboratorios_Click(object sender, EventArgs e)
        {
            frmLaboratorios frm = DI.Create<frmLaboratorios>();
            frm.ShowDialog(this);
        }

        private void btnFormasFarmaceuticas_Click(object sender, EventArgs e)
        {
            frmFormasFarmaceuticas frm = DI.Create<frmFormasFarmaceuticas>();
            frm.ShowDialog(this);
        }
    }
}
