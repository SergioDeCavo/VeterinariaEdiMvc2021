using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosProvincia : IServiciosProvincia
    {
        private readonly IRepositorioProvincias _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosProvincia(IRepositorioProvincias repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(ProvinciaEditDto provinciaDto)
        {
            try
            {
                Provincia provincia = _mapper.Map<Provincia>(provinciaDto);
                return _repositorio.EstaRelacionado(provincia);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProvinciaEditDto provinciaDto)
        {
            try
            {
                Provincia provincia = _mapper.Map<Provincia>(provinciaDto);
                return _repositorio.Existe(provincia);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<ProvinciaListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<ProvinciaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public ProvinciaEditDto GetProvinciaPorId(int? id)
        {
            try
            {
                return _repositorio.GetProvinciaPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(ProvinciaEditDto provinciaDto)
        {
            try
            {
                Provincia provincia = _mapper.Map<Provincia>(provinciaDto);
                _repositorio.Guardar(provincia);
                _unitOfWork.Save();
                provinciaDto.ProvinciaId = provincia.ProvinciaId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
