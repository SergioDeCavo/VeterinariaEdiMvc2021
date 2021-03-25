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
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeMedicamentos : Form
    {
        //private static frmTiposDeMedicamentos instancia;
        //public static frmTiposDeMedicamentos GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmTiposDeMedicamentos();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmTiposDeMedicamentos(IServiciosTipoDeMedicamento servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IServiciosTipoDeMedicamento _servicio;
        private List<TipoDeMedicamentoListDto> _lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTiposDeMedicamentos_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosTipoDeMedicamento();
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipoDeMedicamento in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeMedicamento);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeMedicamentoListDto tipoDeMedicamento)
        {
            r.Cells[TiposDeMedicamentos.Index].Value = tipoDeMedicamento.Descripcion;
            r.Tag = tipoDeMedicamento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTiposDeMedicamentosAE frm = DI.Create<frmTiposDeMedicamentosAE>();
            frm.Text = "Agregar nuevo Tipo de Medicamento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeMedicamentoEditDto tipoMedEditDto = frm.GetTipoDeMedicamento();
                    if (_servicio.Existe(tipoMedEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoMedEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoMedListDto = _mapper.Map<TipoDeMedicamentoListDto>(tipoMedEditDto);
                    SetearFila(r, tipoMedListDto);
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
            var tipoMedDto = r.Tag as TipoDeMedicamentoListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {tipoMedDto.Descripcion}",
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
                _servicio.Borrar(tipoMedDto.TipoDeMedicamentoId);
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
            var tipoMedDto = r.Tag as TipoDeMedicamentoListDto;
            frmTiposDeMedicamentosAE frm = new frmTiposDeMedicamentosAE();
            frm.Text = "Editar Tipo de Medicamento";
            TipoDeMedicamentoEditDto tipoMedEditDto = _mapper.Map<TipoDeMedicamentoEditDto>(tipoMedDto);
            frm.SetTipo(tipoMedEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            tipoMedEditDto = frm.GetTipoDeMedicamento();
            if (_servicio.Existe(tipoMedEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _servicio.Guardar(tipoMedEditDto);
                var tipoMedListDto = _mapper.Map<TipoDeMedicamentoListDto>(tipoMedEditDto);
                SetearFila(r, tipoMedListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
