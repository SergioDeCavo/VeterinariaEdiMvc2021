using AutoMapper;
using System;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;
using VeterinariaEdiMvc2021.Entidades.DTOs.Empleado;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Mascota;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.DTOs.Venta;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Carrito;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Cliente;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Droga;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Empleado;
using VeterinariaEdiMvc2021.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Mascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Proveedor;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Raza;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Venta;

namespace VeterinariaEdiMvc2021.Mapeador
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadTipoDeTareaMapping();
            LoadTipoDeServicioMapping();
            LoadTipoDeMedicamentoMapping();
            LoadTipoDeMascotaMapping();
            LoadTipoDeDocumentoMapping();
            LoadProvinciaMapping();
            LoadLaboratorioMapping();
            LoadDrogaMapping();
            LoadFormaFarmaceuticaMapping();
            LoadLocalidadMapping();
            LoadRazaMapping();
            LoadClienteMapping();
            LoadEmpleadoMapping();
            LoadMascotaMapping();
            LoadMedicamentoMapping();
            LoadProveedor();
            LoadCarritoMapping();
            LoadVentasMapping();
            LoadItemVentasMapping();
            
        }

        private void LoadItemVentasMapping()
        {
            CreateMap<ItemVenta, ItemVentaListDto>()
                .ForMember(dest => dest.Medicamento, act => act.MapFrom(src => src.Medicamento.NombreComercial));
        }

        private void LoadCarritoMapping()
        {
            CreateMap<ItemCarrito, ItemCarritoListViewModel>()
                .ForMember(dest => dest.MedicamentoListViewModel, act => act.MapFrom(src => src.Medicamento));
            CreateMap<Medicamento, MedicamentoListViewModel>()
                .ForMember(dest => dest.TipoDeMedicamento, act => act.MapFrom(src => src.TipoDeMedicamento.Descripcion));
        }

        private void LoadProveedor()
        {
            CreateMap<ProveedorEditDto, ProveedorListViewModel>();
            CreateMap<ProveedorListDto, ProveedorListViewModel>().ReverseMap();
            CreateMap<ProveedorEditViewModel, ProveedorEditDto>().ReverseMap();
            CreateMap<ProveedorEditDto, Proveedor>().ReverseMap();
            CreateMap<ProveedorEditDto, ProveedorListDto>().ReverseMap();
        }

        private void LoadMedicamentoMapping()
        {
            CreateMap<MedicamentoEditDto, MedicamentoListViewModel>();
            CreateMap<MedicamentoListDto, MedicamentoListViewModel>().ReverseMap();
            CreateMap<MedicamentoEditViewModel, MedicamentoEditDto>().ReverseMap();
            CreateMap<MedicamentoEditDto, Medicamento>().ReverseMap();
            CreateMap<MedicamentoEditDto, MedicamentoListDto>().ReverseMap();
        }

        private void LoadMascotaMapping()
        {
            CreateMap<MascotaEditDto, MascotaListViewModel>();
            CreateMap<MascotaListDto, MascotaListViewModel>().ReverseMap();
            CreateMap<MascotaEditViewModel, MascotaEditDto>().ReverseMap();
            CreateMap<MascotaEditDto, Mascota>().ReverseMap();
            CreateMap<MascotaEditDto, MascotaListDto>().ReverseMap();
            CreateMap<Mascota, MascotaListViewModel>().ForMember(dest => dest.Nombre, act => act.MapFrom(src => src.TipoDeMascota.Descripcion));

        }

        private void LoadEmpleadoMapping()
        {
            CreateMap<EmpleadoEditDto, EmpleadoListViewModel>();
            CreateMap<EmpleadoListDto, EmpleadoListViewModel>().ReverseMap();
            CreateMap<EmpleadoEditViewModel, EmpleadoEditDto>().ReverseMap();
            CreateMap<EmpleadoEditDto, Empleado>().ReverseMap();
            CreateMap<EmpleadoEditDto, EmpleadoListDto>().ReverseMap();
        }

        private void LoadClienteMapping()
        {
            CreateMap<ClienteEditDto, ClienteListViewModel>();
            CreateMap<ClienteListDto, ClienteListViewModel>().ReverseMap();
            CreateMap<ClienteEditViewModel, ClienteEditDto>().ReverseMap();
            CreateMap<ClienteEditDto, Cliente>().ReverseMap();
            CreateMap<ClienteEditDto, ClienteListDto>().ReverseMap();
        }

        private void LoadRazaMapping()
        {
            CreateMap<RazaEditDto, RazaListViewModel>();
            CreateMap<RazaListDto, RazaListViewModel>().ReverseMap();
            CreateMap<RazaEditViewModel, RazaEditDto>().ReverseMap();
            CreateMap<RazaEditDto, Raza>().ReverseMap();
            CreateMap<RazaEditDto, RazaListDto>().ReverseMap();
        }

        private void LoadLocalidadMapping()
        {
            CreateMap<LocalidadEditDto, LocalidadListViewModel>();
            CreateMap<LocalidadListDto, LocalidadListViewModel>().ReverseMap();
            CreateMap<LocalidadEditViewModel, LocalidadEditDto>().ReverseMap();
            CreateMap<LocalidadEditDto, Localidad>().ReverseMap();
            CreateMap<LocalidadEditDto, LocalidadListDto>().ReverseMap();
            CreateMap<Localidad, LocalidadListViewModel>().ForMember(dest => dest.Provincia, act => act.MapFrom(src => src.Provincia.NombreProvincia));
        }

        private void LoadFormaFarmaceuticaMapping()
        {
            CreateMap<FormaFarmaceutica, FormaFarmaceuticaListDto>();
            CreateMap<FormaFarmaceutica, FormaFarmaceuticaEditDto>().ReverseMap();
            CreateMap<FormaFarmaceuticaListDto, FormaFarmaceuticaListViewModel>().ReverseMap();
            CreateMap<FormaFarmaceuticaEditDto, FormaFarmaceuticaEditViewModel>().ReverseMap();
            CreateMap<FormaFarmaceuticaEditDto, FormaFarmaceuticaListDto>().ReverseMap();
        }

        private void LoadDrogaMapping()
        {
            CreateMap<Droga, DrogaListDto>();
            CreateMap<Droga, DrogaEditDto>().ReverseMap();
            CreateMap<DrogaListDto, DrogaListViewModel>().ReverseMap();
            CreateMap<DrogaEditDto, DrogaEditViewModel>().ReverseMap();
            CreateMap<DrogaEditDto, DrogaListDto>().ReverseMap();
        }

        private void LoadLaboratorioMapping()
        {
            CreateMap<Laboratorio, LaboratorioListDto>();
            CreateMap<Laboratorio, LaboratorioEditDto>().ReverseMap();
            CreateMap<LaboratorioListDto, LaboratorioListViewModel>().ReverseMap();
            CreateMap<LaboratorioEditDto, LaboratorioEditViewModel>().ReverseMap();
            CreateMap<LaboratorioEditDto, LaboratorioListDto>().ReverseMap();
        }

        private void LoadProvinciaMapping()
        {
            CreateMap<Provincia, ProvinciaListDto>();
            CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();
            CreateMap<ProvinciaListDto, ProvinciaListViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaEditViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaListDto>().ReverseMap();
            CreateMap<ProvinciaCantidadListDto, ProvinciaCantidadListViewModel>();
            CreateMap<ProvinciaDetailsDto, ProvinciaDetailsViewModel>().ForMember(dest => dest.Localidades, act => act.MapFrom(src => src.Localidades)); 

        }

        private void LoadTipoDeDocumentoMapping()
        {
            CreateMap<TipoDeDocumento, TipoDeDocumentoListDto>();
            CreateMap<TipoDeDocumento, TipoDeDocumentoEditDto>().ReverseMap();
            CreateMap<TipoDeDocumentoListDto, TipoDeDocumentoListViewModel>().ReverseMap();
            CreateMap<TipoDeDocumentoEditDto, TipoDeDocumentoEditViewModel>().ReverseMap();
            CreateMap<TipoDeDocumentoEditDto, TipoDeDocumentoListDto>().ReverseMap();
        }

        private void LoadTipoDeMascotaMapping()
        {
            CreateMap<TipoDeMascota, TipoDeMascotaListDto>();
            CreateMap<TipoDeMascota, TipoDeMascotaEditDto>().ReverseMap();
            CreateMap<TipoDeMascotaListDto, TipoDeMascotaListViewModel>().ReverseMap();
            CreateMap<TipoDeMascotaEditDto, TipoDeMascotaEditViewModel>().ReverseMap();
            CreateMap<TipoDeMascotaEditDto, TipoDeMascotaListDto>().ReverseMap();
        }

        private void LoadTipoDeMedicamentoMapping()
        {
            CreateMap<TipoDeMedicamento, TipoDeMedicamentoListDto>();
            CreateMap<TipoDeMedicamento, TipoDeMedicamentoEditDto>().ReverseMap();
            CreateMap<TipoDeMedicamentoListDto, TipoDeMedicamentoListViewModel>().ReverseMap();
            CreateMap<TipoDeMedicamentoEditDto, TipoDeMedicamentoEditViewModel>().ReverseMap();
            CreateMap<TipoDeMedicamentoEditDto, TipoDeMedicamentoListDto>().ReverseMap();
        }

        private void LoadTipoDeServicioMapping()
        {
            CreateMap<TipoDeServicio, TipoDeServicioListDto>();
            CreateMap<TipoDeServicio, TipoDeServicioEditDto>().ReverseMap();
            CreateMap<TipoDeServicioListDto, TipoDeServicioListViewModel>().ReverseMap();
            CreateMap<TipoDeServicioEditDto, TipoDeServicioEditViewModel>().ReverseMap();
            CreateMap<TipoDeServicioEditDto, TipoDeServicioListDto>().ReverseMap();
        }

        private void LoadTipoDeTareaMapping()
        {
            CreateMap<TipoDeTarea, TipoDeTareaListDto>();
            CreateMap<TipoDeTarea, TipoDeTareaEditDto>().ReverseMap();
            CreateMap<TipoDeTareaListDto, TipoDeTareaListViewModel>().ReverseMap();
            CreateMap<TipoDeTareaEditDto, TipoDeTareaEditViewModel>().ReverseMap();
            CreateMap<TipoDeTareaEditDto, TipoDeTareaListDto>().ReverseMap();
        }

        private void LoadVentasMapping() 
        {
            CreateMap<Venta, VentaListDto>().ForMember(dest => dest.Cliente, act => act.MapFrom(src => src.Cliente.Apellido + " " + src.Cliente.Nombre));
            CreateMap<VentaListDto, VentaListViewModel>().ReverseMap();
        }
    }
}
