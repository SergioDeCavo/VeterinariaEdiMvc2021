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
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmClientes : Form
    {
        public frmClientes(IServiciosCliente servicio,  IServiciosLocalidad servicioLocalidad)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioLocalidad = servicioLocalidad;
        }

        private IServiciosCliente _servicio;
        private IServiciosLocalidad _servicioLocalidad;
        private List<ClienteListDto> lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
            try
            {
                lista = _servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var cliente in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, cliente);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ClienteListDto cliente)
        {
            r.Cells[cmnCliente.Index].Value = cliente.Apellido;
            r.Cells[cmnDireccion.Index].Value = cliente.Direccion;
            r.Cells[cmnLocalidad.Index].Value = cliente.Localidad;
            r.Cells[cmnTelefonoMovil.Index].Value = cliente.TelefonoMovil;
            r.Tag = cliente;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmClientesAE frm = DI.Create<frmClientesAE>();
            frm.Text = "Agregar nuevo Cliente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClienteEditDto clienteEditDto = frm.GetCliente();
                    if (_servicio.Existe(clienteEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(clienteEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var clienteListDto = _mapper.Map<ClienteListDto>(clienteEditDto);
                    clienteListDto.Localidad = _servicioLocalidad.GetLocalidadPorId(clienteEditDto.LocalidadId).NombreLocalidad;
                    SetearFila(r, clienteListDto);
                    AgregarFila(r);
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var clienteListDto = r.Tag as ClienteListDto;
            var clienteListDtoCopia = (ClienteListDto)clienteListDto.Clone();
            frmClientesAE frm = new frmClientesAE();
            frm.Text = "Editar Cliente";
            ClienteEditDto clienteEditDto = _servicio.GetClientePorId(clienteListDto.ClienteId);
            frm.SetCliente(clienteEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            clienteEditDto = frm.GetCliente();
            if (_servicio.Existe(clienteEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, clienteListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(clienteEditDto);
                clienteListDto = _mapper.Map<ClienteListDto>(clienteEditDto);
                clienteListDto.Localidad = _servicioLocalidad.GetLocalidadPorId(clienteEditDto.LocalidadId).NombreLocalidad;

                SetearFila(r, clienteListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, clienteListDtoCopia);
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var clienteDto = r.Tag as ClienteListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {clienteDto.Apellido}, {clienteDto.Nombre} ?",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _servicio.Borrar(clienteDto.ClienteId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show("Registro borrado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarProvincias frm = DI.Create<frmBuscarProvincias>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var provinciaDto = frm.GetProvincia();
            try
            {
                lista = _servicio.GetLista(provinciaDto.NombreProvincia);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                lista = _servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
