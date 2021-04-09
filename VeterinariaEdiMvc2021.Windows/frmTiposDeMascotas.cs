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
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmTiposDeMascotas : Form
    {
        //private static frmTiposDeMascotas instancia;
        //public static frmTiposDeMascotas GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmTiposDeMascotas();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmTiposDeMascotas(IServiciosTipoDeMascota servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IServiciosTipoDeMascota _servicio;
        private List<TipoDeMascotaListDto> _lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTiposDeMascotas_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosTipoDeMascota();
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
            foreach (var tipoDeMascota in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeMascota);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeMascotaListDto tipoDeMascota)
        {
            r.Cells[TiposDeMascotas.Index].Value = tipoDeMascota.Descripcion;
            r.Tag = tipoDeMascota;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTiposDeMascotasAE frm = DI.Create<frmTiposDeMascotasAE>();
            frm.Text = "Agregar nuevo Tipo de Mascota";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeMascotaEditDto tipoMasEditDto = frm.GetTipoDeMascota();
                    if (_servicio.Existe(tipoMasEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoMasEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoMasListDto = _mapper.Map<TipoDeMascotaListDto>(tipoMasEditDto);
                    SetearFila(r, tipoMasListDto);
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
            var tipoMasDto = r.Tag as TipoDeMascotaListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {tipoMasDto.Descripcion}",
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
                _servicio.Borrar(tipoMasDto.TipoDeMascotaId);
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
            var tipoMasDto = r.Tag as TipoDeMascotaListDto;
            frmTiposDeMascotasAE frm = new frmTiposDeMascotasAE();
            frm.Text = "Editar Tipo de Mascota";
            TipoDeMascotaEditDto tipoMasEditDto = _mapper.Map<TipoDeMascotaEditDto>(tipoMasDto);
            frm.SetTipo(tipoMasEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            tipoMasEditDto = frm.GetTipoDeMascota();
            if (_servicio.Existe(tipoMasEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _servicio.Guardar(tipoMasEditDto);
                var tipoMasListDto = _mapper.Map<TipoDeMascotaListDto>(tipoMasEditDto);
                SetearFila(r, tipoMasListDto);
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
