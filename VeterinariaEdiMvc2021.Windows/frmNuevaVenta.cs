using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.DTOs.Venta;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmNuevaVenta : Form
    {
        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        private Venta venta;
        private ItemVenta itemVenta;
        private Cliente cliente;
        private IMapper _mapper;
        private Medicamento medicamento;

        public Cliente GetCliente()
        {
            return cliente;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
            Helpers.Helper.CargarComboClientes(ref cboCliente, null);
            Helpers.Helper.CargarComboTipoDeMedicamentos(ref cboTipoDeMedicamento);

            if (venta == null)
            {
                return;
            }

            Helpers.Helper.CargarComboMedicamentos(ref cboMedicamento, null);




        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboTipoDeMedicamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDeMedicamento.SelectedIndex > 0)
            {
                var tipoDeMedicamento = (TipoDeMedicamentoListDto)cboTipoDeMedicamento.SelectedItem;
                Helpers.Helper.CargarComboMedicamentos(ref cboMedicamento, tipoDeMedicamento.Descripcion);
            }
            else
            {
                cboMedicamento.DataSource = null;
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex > 0)
            {
                cliente = (Cliente)cboCliente.SelectedItem;
                txtDireccion.Text = cliente.Direccion;
                txtProvincia.Text = cliente.Provincia.NombreProvincia;
                txtLocalidad.Text = cliente.Localidad.NombreLocalidad;
            }
            else
            {
                cliente = null;
                InicializarControlesCliente();
            }
        }

        private void InicializarControlesCliente()
        {
            cboCliente.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            txtPrecioTotal.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            //cboTipoDeMedicamento.SelectedIndex = 0;
            //cboMedicamento.SelectedIndex = 0;
            cboCliente.Focus();
        }

        private void cboMedicamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMedicamento.SelectedIndex > 0)
            {
                medicamento = (Medicamento)cboMedicamento.SelectedItem;
                txtPrecio.Text = medicamento.PrecioVenta.ToString();
                txtStock.Text = medicamento.UnidadesEnStock.ToString();
            }
            else
            {
                medicamento = null;
            }
        }
    }
}
