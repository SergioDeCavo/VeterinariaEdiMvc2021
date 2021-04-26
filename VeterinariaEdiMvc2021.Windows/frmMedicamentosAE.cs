using System;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;

namespace VeterinariaEdiMvc2021.Windows
{
    public partial class frmMedicamentosAE : Form
    {
        public frmMedicamentosAE()
        {
            InitializeComponent();
        }

        private MedicamentoEditDto medicamentoDto;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public MedicamentoEditDto GetMedicamento()
        {
            return medicamentoDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helpers.Helper.CargarComboTipoDeMedicamentos(ref cboTipoDeMedicamento);
            Helpers.Helper.CargarComboFormaFarmaceuticas(ref cboFormaFarmaceutica);
            Helpers.Helper.CargarComboLaboratorios(ref cboLaboratorio);

            if (medicamentoDto == null)
            {
                return;
            }

            txtNombreComercial.Text = medicamentoDto.NombreComercial;
            cboTipoDeMedicamento.SelectedValue = medicamentoDto.TipoDeMedicamentoId;
            cboFormaFarmaceutica.SelectedValue = medicamentoDto.FormaFarmaceuticaId;
            cboLaboratorio.SelectedValue = medicamentoDto.LaboratorioId;
            txtPrecioDeVenta.Text = medicamentoDto.PrecioVenta.ToString();
            txtUnidadesEnStock.Text = medicamentoDto.UnidadesEnStock.ToString();
            txtNivelDeReposicion.Text = medicamentoDto.NivelDeReposicion.ToString();
            txtCantidadesPorUnidad.Text = medicamentoDto.CantidadesPorUnidad;
            chbSuspendido.Checked = medicamentoDto.Suspendido;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (medicamentoDto == null)
                {
                    medicamentoDto = new MedicamentoEditDto();
                }
                medicamentoDto.NombreComercial = txtNombreComercial.Text;
                medicamentoDto.TipoDeMedicamentoId = ((TipoDeMedicamentoListDto)cboTipoDeMedicamento.SelectedItem).TipoDeMedicamentoId;
                medicamentoDto.FormaFarmaceuticaId = ((FormaFarmaceuticaListDto)cboFormaFarmaceutica.SelectedItem).FormaFarmaceuticaId;
                medicamentoDto.LaboratorioId = ((LaboratorioListDto)cboLaboratorio.SelectedItem).LaboratorioId;
                medicamentoDto.PrecioVenta = decimal.Parse(txtPrecioDeVenta.Text);
                medicamentoDto.UnidadesEnStock = int.Parse(txtUnidadesEnStock.Text);
                medicamentoDto.NivelDeReposicion = int.Parse(txtNivelDeReposicion.Text);
                medicamentoDto.CantidadesPorUnidad = txtCantidadesPorUnidad.Text;
                medicamentoDto.Suspendido = chbSuspendido.Checked;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            return valido;
        }

        public void SetMedicamento(MedicamentoEditDto medicamentoEditDto)
        {
            medicamentoDto = medicamentoEditDto;
        }
    }
}
