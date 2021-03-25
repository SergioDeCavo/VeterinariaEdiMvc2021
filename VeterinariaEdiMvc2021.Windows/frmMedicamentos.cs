using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmMedicamentos : Form
    {
        private static frmMedicamentos instancia;
        public static frmMedicamentos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmMedicamentos();
                instancia.FormClosed += Form_Closed;
            }
            return instancia;
        }

        private static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
        public frmMedicamentos()
        {
            InitializeComponent();
        }

        

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
