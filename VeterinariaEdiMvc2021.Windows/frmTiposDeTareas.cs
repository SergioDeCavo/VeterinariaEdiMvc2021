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
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeTareas : Form
    {
        //private static frmTiposDeTareas instancia;
        //public static frmTiposDeTareas GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmTiposDeTareas();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmTiposDeTareas(IServiciosTipoDeTarea servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IServiciosTipoDeTarea _servicio;
        private List<TipoDeTareaListDto> _lista;
        private IMapper _mapper;


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipoDeTarea in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeTarea);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeTareaListDto tipoDeTarea)
        {
            r.Cells[TiposDeTareas.Index].Value = tipoDeTarea.Descripcion;
            r.Tag = tipoDeTarea;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTiposDeTareasAE frm = DI.Create<frmTiposDeTareasAE>();
            frm.Text = "Agregar nuevo Tipo de Tarea";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeTareaEditDto tipoTarEditDto = frm.GetTipoDeTarea();
                    if (_servicio.Existe(tipoTarEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoTarEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoTarListDto = _mapper.Map<TipoDeTareaListDto>(tipoTarEditDto);
                    SetearFila(r, tipoTarListDto);
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
            var tipoTarDto = r.Tag as TipoDeTareaListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {tipoTarDto.Descripcion}",
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
                _servicio.Borrar(tipoTarDto.TipoDeTareaId);
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
            var tipoTarDto = r.Tag as TipoDeTareaListDto;
            frmTiposDeTareasAE frm = new frmTiposDeTareasAE();
            frm.Text = "Editar Tipo de Tarea";
            TipoDeTareaEditDto tipoTarEditDto = _mapper.Map<TipoDeTareaEditDto>(tipoTarDto);
            frm.SetTipo(tipoTarEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            tipoTarEditDto = frm.GetTipoDeTarea();
            if (_servicio.Existe(tipoTarEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _servicio.Guardar(tipoTarEditDto);
                var tipoTarListDto = _mapper.Map<TipoDeTareaListDto>(tipoTarEditDto);
                SetearFila(r, tipoTarListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmTiposDeTareas_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosTipoDeTarea();
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }
    }
}
