using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmArchivos : Form
    {
        private static frmArchivos instancia;
        public static frmArchivos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new frmArchivos();
                instancia.FormClosed += Form_Closed;
            }
            return instancia;
        }

        private static void Form_Closed(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }
        public frmArchivos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm = DI.Create<frmClientes>();
            frm.ShowDialog(this);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frm = DI.Create<frmProveedores>();
            frm.ShowDialog(this);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados frm = DI.Create<frmEmpleados>();
            frm.ShowDialog(this);
        }

        private void btnProvincias_Click(object sender, EventArgs e)
        {
            frmProvincias frm = DI.Create<frmProvincias>();
            //frmProvincias frm = new frmProvincias(DI.Create<IServiciosProvincia>);
            frm.ShowDialog(this);
        }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            frmLocalidades frm = DI.Create<frmLocalidades>();
            frm.ShowDialog(this);
        }

        private void btnTiposDeDocumentos_Click(object sender, EventArgs e)
        {
            frmTiposDeDocumentos frm = DI.Create<frmTiposDeDocumentos>();
            frm.ShowDialog(this);
        }

        private void btnTiposDeServicios_Click(object sender, EventArgs e)
        {
            frmTiposDeServicios frm = DI.Create<frmTiposDeServicios>();
            frm.ShowDialog(this);
        }

        private void btnTiposDeTareas_Click(object sender, EventArgs e)
        {
            frmTiposDeTareas frm = DI.Create<frmTiposDeTareas>();
            frm.ShowDialog(this);
        }
    }
    
}
