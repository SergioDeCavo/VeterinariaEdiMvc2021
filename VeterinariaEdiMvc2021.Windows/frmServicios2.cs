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
    public partial class frmServicios2 : Form
    {
        private static frmServicios2 instancia;
        public static frmServicios2 GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmServicios2();
                instancia.FormClosed += Form_Closed;
            }
            return instancia;
        }

        private static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
        public frmServicios2()
        {
            InitializeComponent();
        }

        

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
