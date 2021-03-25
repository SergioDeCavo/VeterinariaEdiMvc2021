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
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmLaboratorios : Form
    {
        //private static frmLaboratorios instancia;
        //public static frmLaboratorios GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmLaboratorios();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmLaboratorios(IServiciosLaboratorio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IServiciosLaboratorio _servicio;
        private List<LaboratorioListDto> _lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaboratorios_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosLaboratorio();
                _lista = _servicio.GetLista();
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
            foreach (var laboratorio in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, laboratorio);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, LaboratorioListDto laboratorio)
        {
            r.Cells[Laboratorios.Index].Value = laboratorio.Nombre;
            r.Tag = laboratorio;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmLaboratoriosAE frm = DI.Create<frmLaboratoriosAE>();
            frm.Text = "Agregar nuevo Laboratorio";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LaboratorioEditDto laboratorioEditDto = frm.GetLaboratorio();
                    if (_servicio.Existe(laboratorioEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(laboratorioEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var laboratorioListDto = _mapper.Map<LaboratorioListDto>(laboratorioEditDto);
                    SetearFila(r, laboratorioListDto);
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
            var laboratorioDto = r.Tag as LaboratorioListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {laboratorioDto.Nombre}",
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
                _servicio.Borrar(laboratorioDto.LaboratorioId);
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
            var laboratorioDto = r.Tag as LaboratorioListDto;
            frmLaboratoriosAE frm = new frmLaboratoriosAE();
            frm.Text = "Editar Laboratorio";
            LaboratorioEditDto laboratorioEditDto = _mapper.Map<LaboratorioEditDto>(laboratorioDto);
            frm.SetTipo(laboratorioEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            laboratorioEditDto = frm.GetLaboratorio();
            if (_servicio.Existe(laboratorioEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _servicio.Guardar(laboratorioEditDto);
                var laboratorioListDto = _mapper.Map<LaboratorioListDto>(laboratorioEditDto);
                SetearFila(r, laboratorioListDto);
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
