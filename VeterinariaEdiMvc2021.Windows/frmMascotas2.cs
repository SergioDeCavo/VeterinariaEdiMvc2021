using AutoMapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Mascota;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmMascotas2 : Form
    {
        public frmMascotas2(IServiciosMascota servicio, IServiciosTipoDeMascota servicioTipoMas, IServiciosRaza servicioRaza, IServiciosCliente servicioCliente)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioTipoMas = servicioTipoMas;
            _servicioRaza = servicioRaza;
            _servicioCliente = servicioCliente;
        }

        private IServiciosMascota _servicio;
        private IServiciosTipoDeMascota _servicioTipoMas;
        private IServiciosRaza _servicioRaza;
        private IServiciosCliente _servicioCliente;
        private List<MascotaListDto> lista;
        private IMapper _mapper;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMascotas2_Load(object sender, EventArgs e)
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
            foreach (var mascota in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, mascota);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, MascotaListDto mascota)
        {
            r.Cells[cmnNombre.Index].Value = mascota.Nombre;
            r.Cells[cmnTipoDeMascota.Index].Value = mascota.TipoDeMascota;
            r.Cells[cmnRaza.Index].Value = mascota.Raza;
            r.Cells[cmnCliente.Index].Value = mascota.Cliente;
            r.Tag = mascota;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmMascotas2AE frm = DI.Create<frmMascotas2AE>();
            frm.Text = "Agregar nueva Mascota";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    MascotaEditDto mascotaEditDto = frm.GetMascota();
                    if (_servicio.Existe(mascotaEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(mascotaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var mascotaListDto = _mapper.Map<MascotaListDto>(mascotaEditDto);
                    mascotaListDto.TipoDeMascota = _servicioTipoMas.GetipoDeMascotaPorId(mascotaEditDto.TipoDeMascotaId).Descripcion;
                    mascotaListDto.Raza = _servicioRaza.GetRazaPorId(mascotaEditDto.RazaId).Descripcion;
                    mascotaListDto.Cliente = _servicioCliente.GetClientePorId(mascotaEditDto.ClienteId).Apellido;
                    SetearFila(r, mascotaListDto);
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
            var mascotaListDto = r.Tag as MascotaListDto;
            var mascotaListDtoCopia = (MascotaListDto)mascotaListDto.Clone();
            frmMascotas2AE frm = new frmMascotas2AE();
            frm.Text = "Editar Mascota";
            MascotaEditDto mascotaEditDto = _servicio.GetMascotaPorId(mascotaListDto.MascotaId);
            frm.SetMascota(mascotaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            mascotaEditDto = frm.GetMascota();
            if (_servicio.Existe(mascotaEditDto))
            {
                MessageBox.Show("Registro repetido", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, mascotaListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(mascotaEditDto);
                mascotaListDto = _mapper.Map<MascotaListDto>(mascotaEditDto);
                mascotaListDto.TipoDeMascota = _servicioTipoMas.GetipoDeMascotaPorId(mascotaEditDto.TipoDeMascotaId).Descripcion;
                mascotaListDto.Raza = _servicioRaza.GetRazaPorId(mascotaEditDto.RazaId).Descripcion;
                mascotaListDto.Cliente = _servicioCliente.GetClientePorId(mascotaEditDto.ClienteId).Apellido;

                SetearFila(r, mascotaListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, mascotaListDtoCopia);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var mascotaDto = r.Tag as MascotaListDto;
            DialogResult dr = MessageBox.Show($"Desea dar de baja el registro {mascotaDto.Nombre} ?",
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
                _servicio.Borrar(mascotaDto.MascotaId);
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

