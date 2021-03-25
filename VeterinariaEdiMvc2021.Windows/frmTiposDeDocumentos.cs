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
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeDocumentos : Form
    {
        //private static frmTiposDeDocumentos instancia;
        //public static frmTiposDeDocumentos GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmTiposDeDocumentos();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmTiposDeDocumentos(IServiciosTipoDeDocumento servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IServiciosTipoDeDocumento _servicio;
        private List<TipoDeDocumentoListDto> _lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTiposDeDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosTipoDeDocumento();
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
            foreach (var tipoDeDocumento in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeDocumento);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeDocumentoListDto tipoDeDocumento)
        {
            r.Cells[TiposDeDocumentos.Index].Value = tipoDeDocumento.Descripcion;
            r.Tag = tipoDeDocumento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTiposDeDocumentosAE frm = DI.Create<frmTiposDeDocumentosAE>();
            frm.Text = "Agregar nuevo Tipo de Documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeDocumentoEditDto tipoDocEditDto = frm.GetTipoDeDocumento();
                    if (_servicio.Existe(tipoDocEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoDocEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoDocListDto = _mapper.Map<TipoDeDocumentoListDto>(tipoDocEditDto);
                    SetearFila(r, tipoDocListDto);
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
            var tipoDocDto = r.Tag as TipoDeDocumentoListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {tipoDocDto.Descripcion}",
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
                _servicio.Borrar(tipoDocDto.TipoDeDocumentoId);
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
            var tipoDocDto = r.Tag as TipoDeDocumentoListDto;
            frmTiposDeDocumentosAE frm = new frmTiposDeDocumentosAE();
            frm.Text = "Editar Tipo de Documento";
            TipoDeDocumentoEditDto tipoDocEditDto = _mapper.Map<TipoDeDocumentoEditDto>(tipoDocDto);
            frm.SetTipo(tipoDocEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            tipoDocEditDto = frm.GetTipoDeDocumento();
            if (_servicio.Existe(tipoDocEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _servicio.Guardar(tipoDocEditDto);
                var tipoDocListDto = _mapper.Map<TipoDeDocumentoListDto>(tipoDocEditDto);
                SetearFila(r, tipoDocListDto);
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
