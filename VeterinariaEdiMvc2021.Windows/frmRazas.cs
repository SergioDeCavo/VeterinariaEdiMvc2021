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
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmRazas : Form
    {
        //private static frmRazas instancia;
        //public static frmRazas GetInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new frmRazas();
        //        instancia.FormClosed += Form_Closed;
        //    }
        //    return instancia;
        //}

        //private static void Form_Closed(object sender, FormClosedEventArgs e)
        //{
        //    instancia = null;
        //}
        public frmRazas(IServiciosRaza servicio, IServiciosTipoDeMascota serviciosTipoDeMascota)
        {
            InitializeComponent();
            _servicio = servicio;
            _serviciosTipoDeMascota = serviciosTipoDeMascota;
        }

        private IServiciosTipoDeMascota _serviciosTipoDeMascota; 
        private IServiciosRaza _servicio;
        private List<RazaListDto> lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRazas_Load(object sender, EventArgs e)
        {
            _mapper = VeterinariaEdiMvc2021.Mapeador.Mapeador.CrearMapper();
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

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var raza in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, raza);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, RazaListDto raza)
        {
            r.Cells[cmnRaza.Index].Value = raza.Descripcion;
            r.Cells[cmnTipoDeMascota.Index].Value = raza.TipoDeMascota;
            r.Tag = raza;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmRazasAE frm = DI.Create<frmRazasAE>();
            frm.Text = "Agregar nueva Raza";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    RazaEditDto razaEditDto = frm.GetRaza();
                    if (_servicio.Existe(razaEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(razaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var razaListDto = _mapper.Map<RazaListDto>(razaEditDto);
                    razaListDto.TipoDeMascota = (_serviciosTipoDeMascota.GetipoDeMascotaPorId(razaEditDto.TipoDeMascotaId)).Descripcion;
                    SetearFila(r, razaListDto);
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
            var razaListDto = r.Tag as RazaListDto;
            var razaListDtoCopia = (RazaListDto)razaListDto.Clone();
            frmRazasAE frm = DI.Create<frmRazasAE>();
            frm.Text = "Editar Raza";
            RazaEditDto razaEditDto = _servicio.GetRazaPorId(razaListDto.RazaId);
            frm.SetRaza(razaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            razaEditDto = frm.GetRaza();
            if (_servicio.Existe(razaEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, razaListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(razaEditDto);
                razaListDto = _mapper.Map<RazaListDto>(razaEditDto);
                razaListDto.TipoDeMascota = (_serviciosTipoDeMascota.GetipoDeMascotaPorId(razaEditDto.TipoDeMascotaId)).Descripcion;
                SetearFila(r, razaListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, razaListDtoCopia);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var razaDto = r.Tag as RazaListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {razaDto.Descripcion} {razaDto.TipoDeMascota}?",
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
                _servicio.Borrar(razaDto.RazaId);
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
            frmBuscarTiposDeMascota frm = DI.Create<frmBuscarTiposDeMascota>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }
            var tipoDeMascotaDto = frm.GetTipoDeMascota();
            try
            {
                lista = _servicio.GetLista(tipoDeMascotaDto.Descripcion);
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
    }
    
}
