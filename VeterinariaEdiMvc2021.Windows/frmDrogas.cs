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
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmDrogas : Form
    {
        //private static frmDrogas instancia;
        //public static frmDrogas GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmDrogas();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmDrogas(IServiciosDroga servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IServiciosDroga _servicio;
        private List<DrogaListDto> _lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDrogas_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosDroga();
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
            foreach (var droga in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, droga);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, DrogaListDto droga)
        {
            r.Cells[Drogas.Index].Value = droga.NombreDroga;
            r.Tag = droga;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmDrogasAE frm = DI.Create<frmDrogasAE>();
            frm.Text = "Agregar nueva Droga";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    DrogaEditDto drogaEditDto = frm.GetDroga();
                    if (_servicio.Existe(drogaEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(drogaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var drogaListDto = _mapper.Map<DrogaListDto>(drogaEditDto);
                    SetearFila(r, drogaListDto);
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
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var drogaDto = r.Tag as DrogaListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {drogaDto.NombreDroga}",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr==DialogResult.No)
            {
                return;
            }
            try
            {
                _servicio.Borrar(drogaDto.DrogaId);
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
            var drogaDto = r.Tag as DrogaListDto;
            frmDrogasAE frm = new frmDrogasAE();
            frm.Text = "Editar Droga";
            DrogaEditDto drogaEditDto = _mapper.Map<DrogaEditDto>(drogaDto);
            frm.SetTipo(drogaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            drogaEditDto = frm.GetDroga();
            if (_servicio.Existe(drogaEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _servicio.Guardar(drogaEditDto);
                var drogaListDto = _mapper.Map<DrogaListDto>(drogaEditDto);
                SetearFila(r, drogaListDto);
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
