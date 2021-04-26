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
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmMedicamentos : Form
    {
        //private static frmMedicamentos instancia;
        //public static frmMedicamentos GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmMedicamentos();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmMedicamentos(IServiciosMedicamento servicio, IServiciosTipoDeMedicamento servicioTipoMed, IServiciosFormaFarmaceutica servicioFormafarmaceutica, IServiciosLaboratorio servicioLaboratorio)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioTipoMed = servicioTipoMed;
            _servicioFormaFarmaceutica = servicioFormafarmaceutica;
            _servicioLaboratorio = servicioLaboratorio;
        }

        private IServiciosMedicamento _servicio;
        private IServiciosTipoDeMedicamento _servicioTipoMed;
        private IServiciosFormaFarmaceutica _servicioFormaFarmaceutica;
        private IServiciosLaboratorio _servicioLaboratorio;
        private List<MedicamentoListDto> lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMedicamentos_Load(object sender, EventArgs e)
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
            foreach (var medicamento in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, medicamento);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, MedicamentoListDto medicamento)
        {
            r.Cells[cmnNombreComercial.Index].Value = medicamento.NombreComercial;
            r.Cells[cmnTipoDeMedicamento.Index].Value = medicamento.TipoDeMedicamento;
            r.Cells[cmnFormaFarmaceutica.Index].Value = medicamento.FormaFarmaceutica;
            r.Cells[cmnLaboratorio.Index].Value = medicamento.Laboratorio;
            r.Cells[cmnPrecioVenta.Index].Value = medicamento.PrecioVenta;
            r.Cells[cmnSuspendido.Index].Value = medicamento.Suspendido;
            r.Tag = medicamento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmMedicamentosAE frm = DI.Create<frmMedicamentosAE>();
            frm.Text = "Agregar nuevo Medicamento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    MedicamentoEditDto medicamentoEditDto = frm.GetMedicamento();
                    if (_servicio.Existe(medicamentoEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(medicamentoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var medicamentoListDto = _mapper.Map<MedicamentoListDto>(medicamentoEditDto);
                    medicamentoListDto.TipoDeMedicamento = _servicioTipoMed.GetipoDeMedicamentoPorId(medicamentoEditDto.TipoDeMedicamentoId).Descripcion;
                    medicamentoListDto.FormaFarmaceutica = _servicioFormaFarmaceutica.GetFormaFarmaceuticaPorId(medicamentoEditDto.FormaFarmaceuticaId).Descripcion;
                    medicamentoListDto.Laboratorio = _servicioLaboratorio.GetLaboratorioPorId(medicamentoEditDto.LaboratorioId).Nombre;

                    SetearFila(r, medicamentoListDto);
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
            var medicamentoListDto = r.Tag as MedicamentoListDto;
            var medicamentoListDtoCopia = (MedicamentoListDto)medicamentoListDto.Clone();
            frmMedicamentosAE frm = new frmMedicamentosAE();
            frm.Text = "Editar Medicamento";
            MedicamentoEditDto medicamentoEditDto = _servicio.GetMedicamentoPorId(medicamentoListDto.MedicamentoId);
            frm.SetMedicamento(medicamentoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            medicamentoEditDto = frm.GetMedicamento();
            if (_servicio.Existe(medicamentoEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, medicamentoListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(medicamentoEditDto);
                medicamentoListDto = _mapper.Map<MedicamentoListDto>(medicamentoEditDto);
                medicamentoListDto.TipoDeMedicamento = _servicioTipoMed.GetipoDeMedicamentoPorId(medicamentoEditDto.TipoDeMedicamentoId).Descripcion;
                medicamentoListDto.FormaFarmaceutica = _servicioFormaFarmaceutica.GetFormaFarmaceuticaPorId(medicamentoEditDto.FormaFarmaceuticaId).Descripcion;
                medicamentoListDto.Laboratorio = _servicioLaboratorio.GetLaboratorioPorId(medicamentoEditDto.LaboratorioId).Nombre;

                SetearFila(r, medicamentoListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, medicamentoListDtoCopia);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var medicamentoDto = r.Tag as MedicamentoListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {medicamentoDto.NombreComercial} ?",
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
                _servicio.Borrar(medicamentoDto.MedicamentoId);
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
            frmBuscarTipoDeMedicamentos frm = DI.Create<frmBuscarTipoDeMedicamentos>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            var tipoDeMedicamentoDto = frm.GetTipoDeMedicamento();
            try
            {
                lista = _servicio.GetLista(tipoDeMedicamentoDto.Descripcion);
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
