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
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeServicios : Form
    {
        //private static frmTiposDeServicios instancia;
        //public static frmTiposDeServicios GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmTiposDeServicios();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmTiposDeServicios(IServiciosTipoDeServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IServiciosTipoDeServicio _servicio;
        private List<TipoDeServicioListDto> _lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipoDeServicio in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeServicio);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeServicioListDto tipoDeServicio)
        {
            r.Cells[TiposDeServicios.Index].Value = tipoDeServicio.Descripcion;
            r.Tag = tipoDeServicio;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTiposDeServiciosAE frm = DI.Create<frmTiposDeServiciosAE>();
            frm.Text = "Agregar nuevo Tipo de Servicio";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeServicioEditDto tipoSerEditDto = frm.GetTipoDeServicio();
                    if (_servicio.Existe(tipoSerEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoSerEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoSerListDto = _mapper.Map<TipoDeServicioListDto>(tipoSerEditDto);
                    SetearFila(r, tipoSerListDto);
                    AgregarFila(r);
                    MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var tipoSerDto = r.Tag as TipoDeServicioListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {tipoSerDto.Descripcion}",
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
                _servicio.Borrar(tipoSerDto.TipoDeServicioId);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var tipoSerDto = r.Tag as TipoDeServicioListDto;
            frmTiposDeServiciosAE frm = new frmTiposDeServiciosAE();
            frm.Text = "Editar Tipo de Servicio";
            TipoDeServicioEditDto tipoSerEditDto = _mapper.Map<TipoDeServicioEditDto>(tipoSerDto);
            frm.SetTipo(tipoSerEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            tipoSerEditDto = frm.GetTipoDeServicio();
            if (_servicio.Existe(tipoSerEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _servicio.Guardar(tipoSerEditDto);
                var tipoSerListDto = _mapper.Map<TipoDeServicioListDto>(tipoSerEditDto);
                SetearFila(r, tipoSerListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmTiposDeServicios_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosTipoDeServicio();
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception("Error");
            }
        }
    }
}
