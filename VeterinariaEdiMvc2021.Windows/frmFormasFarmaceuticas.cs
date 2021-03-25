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
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmFormasFarmaceuticas : Form
    {
        //private static frmFormasFarmaceuticas instancia;
        //public static frmFormasFarmaceuticas GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmFormasFarmaceuticas();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmFormasFarmaceuticas(IServiciosFormaFarmaceutica servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IServiciosFormaFarmaceutica _servicio;
        private List<FormaFarmaceuticaListDto> _lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFormasFarmaceuticas_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosFormaFarmaceutica();
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
            foreach (var formaFarmaceutica in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, formaFarmaceutica);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, FormaFarmaceuticaListDto formaFarmaceutica)
        {
            r.Cells[FormasFarmaceuticas.Index].Value = formaFarmaceutica.Descripcion;
            r.Tag = formaFarmaceutica;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFormasFarmaceuticasAE frm = DI.Create< frmFormasFarmaceuticasAE>();
            frm.Text = "Agregar nueva Forma Farmacèutica";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    FormaFarmaceuticaEditDto formaFarmaceuticaEditDto = frm.GetForma();
                    if (_servicio.Existe(formaFarmaceuticaEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(formaFarmaceuticaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var formaFarmaceuticaListDto = _mapper.Map<FormaFarmaceuticaListDto>(formaFarmaceuticaEditDto);
                    SetearFila(r, formaFarmaceuticaListDto);
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
            var formaDto = r.Tag as FormaFarmaceuticaListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {formaDto.Descripcion}",
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
                _servicio.Borrar(formaDto.FormaFarmaceuticaId);
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
            var formaDto = r.Tag as FormaFarmaceuticaListDto;
            frmFormasFarmaceuticasAE frm = new frmFormasFarmaceuticasAE();
            frm.Text = "Editar Forma Farmacèutica";
            FormaFarmaceuticaEditDto formaEditDto = _mapper.Map<FormaFarmaceuticaEditDto>(formaDto);
            frm.SetTipo(formaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            formaEditDto = frm.GetForma();
            if (_servicio.Existe(formaEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _servicio.Guardar(formaEditDto);
                var formaListDto = _mapper.Map<FormaFarmaceuticaListDto>(formaEditDto);
                SetearFila(r, formaListDto);
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
