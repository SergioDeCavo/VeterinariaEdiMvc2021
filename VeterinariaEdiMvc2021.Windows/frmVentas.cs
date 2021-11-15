using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Venta;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmVentas : Form
    {
        //private readonly IServiciosVenta _servicio;
        
        //public frmVentas(IServiciosVenta servicio)
        //{
        //    _servicio = servicio;
        //    InitializeComponent();
        //}


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<VentaListDto> lista;

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                //lista = _servicio.GetVenta();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception("Error");
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var venta in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, venta);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, VentaListDto venta)
        {
            r.Cells[cmnVentaId.Index].Value = venta.VentaId;
            r.Cells[cmnFecha.Index].Value = venta.FechaVenta;
            r.Cells[cmnCliente.Index].Value = venta.Cliente;
            r.Cells[cmnAnulado.Index].Value = venta.Anulado;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            try
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                var venta = (Venta)r.Tag;
                frmItemVentas frm = DI.Create<frmItemVentas>();
                frm.SetVenta(venta);
                frm.ShowDialog(this);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmNuevaVenta frm = DI.Create<frmNuevaVenta>();
            frm.Text = "Agregar nueva Venta";
            DialogResult dr = frm.ShowDialog(this);
        }
    }
}
