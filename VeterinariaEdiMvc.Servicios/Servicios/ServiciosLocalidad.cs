using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosLocalidad : IServiciosLocalidad
    {
        private readonly IRepositorioLocalidades _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosLocalidad(IRepositorioLocalidades repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int localidadId)
        {
            try
            {
                _repositorio.Borrar(localidadId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(LocalidadEditDto localidadDto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(LocalidadEditDto localidadEditDto)
        {
            try
            {
                Localidad localidad = _mapper.Map<Localidad>(localidadEditDto);
                return _repositorio.Existe(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public List<LocalidadListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return _repositorio.GetLocalidadPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Guardar(LocalidadEditDto localidadDto)
        {
            try
            {
                Localidad localidad = _mapper.Map<Localidad>(localidadDto);
                _repositorio.Guardar(localidad);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
