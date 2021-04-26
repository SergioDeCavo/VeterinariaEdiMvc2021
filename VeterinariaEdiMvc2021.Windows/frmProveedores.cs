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
using VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmProveedores : Form
    {
        //private static frmProveedores instancia;
        //public static frmProveedores GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmProveedores();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmProveedores(IServiciosProveedor servicio, IServiciosLocalidad servicioLocalidad)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioLocalidad = servicioLocalidad;
        }

        private IServiciosProveedor _servicio;
        private IServiciosLocalidad _servicioLocalidad;
        private List<ProveedorListDto> lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
            try
            {
                lista = _servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var proveedor in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, proveedor);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ProveedorListDto proveedor)
        {
            r.Cells[cmnCUIT.Index].Value = proveedor.CUIT;
            r.Cells[cmnRazonSocial.Index].Value = proveedor.RazonSocial;
            r.Cells[cmnDireccion.Index].Value = proveedor.Direccion;
            r.Cells[cmnLocalidad.Index].Value = proveedor.Localidad;
            r.Cells[cmnTelefonoMovil.Index].Value = proveedor.TelefonoMovil;
            r.Tag = proveedor;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProveedoresAE frm = DI.Create<frmProveedoresAE>();
            frm.Text = "Agregar nuevo Proveedor";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ProveedorEditDto proveedorEditDto = frm.GetProveedor();
                    if (_servicio.Existe(proveedorEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(proveedorEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var proveedorListDto = _mapper.Map<ProveedorListDto>(proveedorEditDto);
                    proveedorListDto.Localidad = _servicioLocalidad.GetLocalidadPorId(proveedorEditDto.LocalidadId).NombreLocalidad;
                    SetearFila(r, proveedorListDto);
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
            var proveedorListDto = r.Tag as ProveedorListDto;
            var proveedorListDtoCopia = (ProveedorListDto)proveedorListDto.Clone();
            frmProveedoresAE frm = new frmProveedoresAE();
            frm.Text = "Editar Proveedor";
            ProveedorEditDto proveedorEditDto = _servicio.GetProveedorPorId(proveedorListDto.ProveedorId);
            frm.SetProveedor(proveedorEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            proveedorEditDto = frm.GetProveedor();
            if (_servicio.Existe(proveedorEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, proveedorListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(proveedorEditDto);
                proveedorListDto = _mapper.Map<ProveedorListDto>(proveedorEditDto);
                proveedorListDto.Localidad = _servicioLocalidad.GetLocalidadPorId(proveedorEditDto.LocalidadId).NombreLocalidad;
                SetearFila(r, proveedorListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, proveedorListDtoCopia);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var proveedorDto = r.Tag as ProveedorListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {proveedorDto.RazonSocial} ?",
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
                _servicio.Borrar(proveedorDto.ProveedorId);
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
            frmBuscarLocalidades frm = DI.Create<frmBuscarLocalidades>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var localidadDto = frm.GetLocalidad();
            try
            {
                lista = _servicio.GetLista(localidadDto.NombreLocalidad);
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
