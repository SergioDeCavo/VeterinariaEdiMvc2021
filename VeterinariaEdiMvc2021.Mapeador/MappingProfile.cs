using AutoMapper;
using System;
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Droga;
using VeterinariaEdiMvc2021.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Raza;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeTarea;

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
        }

        private void LoadRazaMapping()
        {
            CreateMap<RazaListDto, RazaListViewModel>().ReverseMap();
            CreateMap<RazaEditViewModel, RazaEditDto>().ReverseMap();
            CreateMap<RazaEditDto, Raza>().ReverseMap();
            CreateMap<RazaEditDto, RazaListDto>().ReverseMap();
        }

        private void LoadLocalidadMapping()
        {
            CreateMap<LocalidadListDto, LocalidadListViewModel>().ReverseMap();
            CreateMap<LocalidadEditViewModel, LocalidadEditDto>().ReverseMap();
            CreateMap<LocalidadEditDto, Localidad>().ReverseMap();
            CreateMap<LocalidadEditDto, LocalidadListDto>().ReverseMap();
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

        
    }
}
