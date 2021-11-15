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
using VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Helpers;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmItemVentas : Form
    {
        private IServiciosItemVenta _servicio;

        public frmItemVentas(IServiciosItemVenta _servicio)
        {
            this._servicio = _servicio;
            InitializeComponent();
        }

        public frmItemVentas()
        {
        }

        private Venta venta;
        private List<ItemVentaListDto> lista;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetVenta(Venta venta)
        {
            this.venta = venta;
        }

        private void frmItemVentas_Load(object sender, EventArgs e)
        {
            lista = _servicio.GetItemVentas();
            MostrarDatosEnGrilla();
            MostrarEncabezado();
            MostrarDetalle();
            MostrarTotal();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var itemVenta in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, itemVenta);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ItemVentaListDto itemVenta)
        {
            r.Cells[cmnMedicamento.Index].Value = itemVenta.Medicamento;
            r.Cells[cmnPrecio.Index].Value = itemVenta.PrecioVenta;
            r.Cells[cmnCantidad.Index].Value = itemVenta.Cantidad;
            //r.Cells[cmnTotal.Index].Value = itemVenta.;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void MostrarTotal()
        {
            txtTotal.Text = HelperCalculos
                .CalcularTotalOrden(venta.ItemVentas).ToString();
        }

        private void MostrarDetalle()
        {
            throw new NotImplementedException();
        }

        private void MostrarEncabezado()
        {
            txtNumero.Text = venta.VentaId.ToString();
            txtFecha.Text = venta.FechaVenta.ToShortDateString();
            txtCliente.Text = venta.Cliente.Apellido;
            txtDireccion.Text = venta.Cliente.Direccion;
            txtCiudad.Text = venta.Cliente.Provincia.NombreProvincia;
            txtProvincia.Text = venta.Cliente.Localidad.NombreLocalidad;
        }
    }
}
