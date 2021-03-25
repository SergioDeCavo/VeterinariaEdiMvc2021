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
    public partial class frmProveedores : Form
    {
        private static frmProveedores instancia;
        public static frmProveedores GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmProveedores();
                instancia.FormClosed += Form_Closed;
            }
            return instancia;
        }

        private static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
        public frmProveedores()
        {
            InitializeComponent();
        }

        

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
