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
    public partial class frmRazas : Form
    {
        private static frmRazas instancia;
        public static frmRazas GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmRazas();
                instancia.FormClosed += Form_Closed;
            }
            return instancia;
        }

        private static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
        public frmRazas()
        {
            InitializeComponent();
        }

        

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
