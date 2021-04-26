using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosTipoDeServicio : IServiciosTipoDeServicio
    {
        private readonly IRepositorioTipoDeServicios _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosTipoDeServicio(IRepositorioTipoDeServicios repositorio, IUnitOfWork unitOfWork)
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

        //public bool EstaRelacionado(TipoDeServicioEditDto tipoSerDto)
        //{
        //    try
        //    {
        //        TipoDeServicio tipoDeServicio = _mapper.Map<TipoDeServicio>(tipoSerDto);
        //        return _repositorio.EstaRelacionado(tipoDeServicio);
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }
        //}

        public bool Existe(TipoDeServicioEditDto tipoDeServicioDto)
        {
            try
            {
                TipoDeServicio tipoDeServicio = _mapper.Map<TipoDeServicio>(tipoDeServicioDto);
                return _repositorio.Existe(tipoDeServicio);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeServicioEditDto GetipoDeServicioPorId(int? id)
        {
            try
            {
                return _repositorio.GetipoDeServicioPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDeServicioListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<TipoDeServicioListDto>>(lista);
            }
            catch (Exception ex)
            {

                throw new Exception("Error");
            }
        }

        public void Guardar(TipoDeServicioEditDto tipoDeServicioDto)
        {
            try
            {
                TipoDeServicio tipoDeServicio = _mapper.Map<TipoDeServicio>(tipoDeServicioDto);
                _repositorio.Guardar(tipoDeServicio);
                _unitOfWork.Save();
                tipoDeServicioDto.TipoDeServicioId = tipoDeServicio.TipoDeServicioId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
