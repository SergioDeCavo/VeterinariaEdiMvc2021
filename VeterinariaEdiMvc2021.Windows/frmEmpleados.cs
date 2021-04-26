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
using VeterinariaEdiMvc2021.Entidades.DTOs.Empleado;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmEmpleados : Form
    {
        //private static frmEmpleados instancia;
        //public static frmEmpleados GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmEmpleados();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmEmpleados(IServiciosEmpleado servicio, IServiciosLocalidad servicioLocalidad, IServiciosTipoDeTarea servicioTipoDeTarea)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioLocalidad = servicioLocalidad;
            _servicioTipoDeTarea = servicioTipoDeTarea;
        }

        private IServiciosEmpleado _servicio;
        private IServiciosLocalidad _servicioLocalidad;
        private IServiciosTipoDeTarea _servicioTipoDeTarea;
        private List<EmpleadoListDto> lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
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
            foreach (var empleado in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, empleado);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, EmpleadoListDto empleado)
        {
            r.Cells[cmnEmpleado.Index].Value = empleado.Apellido;
            r.Cells[cmnDireccion.Index].Value = empleado.Direccion;
            r.Cells[cmnLocalidad.Index].Value = empleado.Localidad;
            r.Cells[cmnTelefonoMovil.Index].Value = empleado.TelefonoMovil;
            r.Cells[cmnTipoDeTarea.Index].Value = empleado.TipoDeTarea;
            r.Tag = empleado;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmEmpleadosAE frm = DI.Create<frmEmpleadosAE>();
            frm.Text = "Agregar nuevo empleado";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    EmpleadoEditDto empleadoEditDto = frm.GetEmpleado();
                    if (_servicio.Existe(empleadoEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(empleadoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var empleadoListDto = _mapper.Map<EmpleadoListDto>(empleadoEditDto);
                    empleadoListDto.Localidad = _servicioLocalidad.GetLocalidadPorId(empleadoEditDto.LocalidadId).NombreLocalidad;
                    empleadoListDto.TipoDeTarea = _servicioTipoDeTarea.GetipoDeTareaPorId(empleadoEditDto.TipoDeTareaId).Descripcion;

                    SetearFila(r, empleadoListDto);
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
            var empleadoListDto = r.Tag as EmpleadoListDto;
            var empleadoListDtoCopia = (EmpleadoListDto)empleadoListDto.Clone();
            frmEmpleadosAE frm = new frmEmpleadosAE();
            frm.Text = "Editar Empleado";
            EmpleadoEditDto empleadoEditDto = _servicio.GetEmpleadoPorId(empleadoListDto.EmpleadoId);
            frm.SetEmpleado(empleadoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            empleadoEditDto = frm.GetEmpleado();
            if (_servicio.Existe(empleadoEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, empleadoListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(empleadoEditDto);
                empleadoListDto = _mapper.Map<EmpleadoListDto>(empleadoEditDto);
                empleadoListDto.Localidad = _servicioLocalidad.GetLocalidadPorId(empleadoEditDto.LocalidadId).NombreLocalidad;
                empleadoListDto.TipoDeTarea = _servicioTipoDeTarea.GetipoDeTareaPorId(empleadoEditDto.TipoDeTareaId).Descripcion;

                SetearFila(r, empleadoListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, empleadoListDtoCopia);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var empleadoDto = r.Tag as EmpleadoListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {empleadoDto.Apellido}, {empleadoDto.Nombre} ?",
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
                _servicio.Borrar(empleadoDto.EmpleadoId);
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
            frmBuscarTipoDeTarea frm = DI.Create<frmBuscarTipoDeTarea>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var tipoDeTareaDto = frm.GetTipoDeTarea();
            try
            {
                lista = _servicio.GetLista(tipoDeTareaDto.Descripcion);
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
