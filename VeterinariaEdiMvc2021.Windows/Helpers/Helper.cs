using System;
using System.Windows.Forms;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows.Helpers
{
    public class Helper
    {
        public static void CargarComboTiposDeMascota(ref ComboBox combo) 
        {
            IServiciosTipoDeMascota serviciosTipoDeMascota = DI.Create<IServiciosTipoDeMascota>();
            var lista = serviciosTipoDeMascota.GetLista();
            var defaultTipoDeMascota = new TipoDeMascotaListDto
            {
                TipoDeMascotaId = 0,
                Descripcion = "<Seleccione un Tipo de Mascota>"
            };
            lista.Insert(0, defaultTipoDeMascota);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDeMascotaId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboProvincias(ref ComboBox combo)
        {
            IServiciosProvincia serviciosProvincia = DI.Create<IServiciosProvincia>();
            var lista = serviciosProvincia.GetLista();
            var defaultProvincia = new ProvinciaListDto
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccione una Provincia>"
            };
            lista.Insert(0, defaultProvincia);
            combo.DataSource = lista;
            combo.ValueMember = "ProvinciaId";
            combo.DisplayMember = "NombreProvincia";
            combo.SelectedIndex = 0;

        }

        public static void CargarComboTipoDeDocumentos(ref ComboBox combo)
        {
            IServiciosTipoDeDocumento serviciosTipoDeDocumento = DI.Create<IServiciosTipoDeDocumento>();
            var lista = serviciosTipoDeDocumento.GetLista();
            var defaultTipo = new TipoDeDocumentoListDto
            {
                TipoDeDocumentoId = 0,
                Descripcion = "<Seleccione un Tipo>"
            };
            lista.Insert(0, defaultTipo);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDeDocumentoId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboLocalidades(ref ComboBox combo, string nombreProvincia)
        {
            IServiciosLocalidad serviciosLocalidad = DI.Create<IServiciosLocalidad>();
            var lista2 = serviciosLocalidad.GetLista(nombreProvincia);
            var defaultTipo2 = new LocalidadListDto
            {
                LocalidadId = 0,
                NombreLocalidad = "<Seleccione una Localidad>"
            };
            lista2.Insert(0, defaultTipo2);
            combo.DataSource = lista2;
            combo.ValueMember = "LocalidadId";
            combo.DisplayMember = "NombreLocalidad";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboTipoDeTareas(ref ComboBox combo)
        {
            IServiciosTipoDeTarea serviciosTipoDetarea = DI.Create<IServiciosTipoDeTarea>();
            var lista3 = serviciosTipoDetarea.GetLista();
            var defaultTipo3 = new TipoDeTareaListDto
            {
                TipoDeTareaId = 0,
                Descripcion = "<Seleccione un Tipo>"
            };
            lista3.Insert(0, defaultTipo3);
            combo.DataSource = lista3;
            combo.ValueMember = "TipoDeTareaId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboRazas(ref ComboBox combo)
        {
            IServiciosRaza serviciosRaza = DI.Create<IServiciosRaza>();
            var lista2 = serviciosRaza.GetLista(null);
            var defaultTipo2 = new RazaListDto
            {
                RazaId = 0,
                Descripcion = "<Seleccione una Raza>"
            };
            lista2.Insert(0, defaultTipo2);
            combo.DataSource = lista2;
            combo.ValueMember = "RazaId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboClientes(ref ComboBox combo, string nombreLocalidad)
        {
            IServiciosCliente serviciosCliente = DI.Create<IServiciosCliente>();
            var lista3 = serviciosCliente.GetLista(nombreLocalidad);
            var defaultTipo3 = new ClienteListDto
            {
                ClienteId = 0,
                Apellido = "<Seleccione un Apellido>"
            };
            lista3.Insert(0, defaultTipo3);
            combo.DataSource = lista3;
            combo.ValueMember = "ClienteId";
            combo.DisplayMember = "Apellido";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboTipoDeMedicamentos(ref ComboBox combo)
        {
            IServiciosTipoDeMedicamento serviciosTipoDeMedicamento = DI.Create<IServiciosTipoDeMedicamento>();
            var lista = serviciosTipoDeMedicamento.GetLista();
            var defaultTipo = new TipoDeMedicamentoListDto
            {
                TipoDeMedicamentoId = 0,
                Descripcion = "<Seleccione un Tipo>"
            };
            lista.Insert(0, defaultTipo);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDeMedicamentoId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboFormaFarmaceuticas(ref ComboBox combo)
        {
            IServiciosFormaFarmaceutica serviciosFormaFarmaceutica = DI.Create<IServiciosFormaFarmaceutica>();
            var lista2 = serviciosFormaFarmaceutica.GetLista();
            var defaultTipo2 = new FormaFarmaceuticaListDto
            {
                FormaFarmaceuticaId = 0,
                Descripcion = "<Seleccione una F. Farm.>"
            };
            lista2.Insert(0, defaultTipo2);
            combo.DataSource = lista2;
            combo.ValueMember = "FormaFarmaceuticaId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboLaboratorios(ref ComboBox combo)
        {
            IServiciosLaboratorio serviciosLaboratorio = DI.Create<IServiciosLaboratorio>();
            var lista3 = serviciosLaboratorio.GetLista();
            var defaultTipo3 = new LaboratorioListDto
            {
                LaboratorioId = 0,
                Nombre = "<Seleccione un Laboratorio>"
            };
            lista3.Insert(0, defaultTipo3);
            combo.DataSource = lista3;
            combo.ValueMember = "LaboratorioId";
            combo.DisplayMember = "Nombre";
            combo.SelectedIndex = 0;

        }

        public static void CargarComboMedicamentos(ref ComboBox combo, string tipoDeMedicamento)
        {
            IServiciosMedicamento serviciosMedicamento = DI.Create<IServiciosMedicamento>();
            var lista2 = serviciosMedicamento.GetLista(tipoDeMedicamento);
            var defaultTipo2 = new MedicamentoListDto
            {
                MedicamentoId = 0,
                NombreComercial = "<Seleccione un Medicamento>"
            };
            lista2.Insert(0, defaultTipo2);
            combo.DataSource = lista2;
            combo.ValueMember = "MedicamentoId";
            combo.DisplayMember = "NombreComercial";
            combo.SelectedIndex = 0;
        }

    }
}
