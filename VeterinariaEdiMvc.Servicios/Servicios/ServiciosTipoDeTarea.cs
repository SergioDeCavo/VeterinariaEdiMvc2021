using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosTipoDeTarea : IServiciosTipoDeTarea
    {
        private readonly IRepositorioTipoDeTareas _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosTipoDeTarea(IRepositorioTipoDeTareas repositorio, IUnitOfWork unitOfWork)
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

        public bool Existe(TipoDeTareaEditDto tipoDeTareaDto)
        {
            try
            {
                TipoDeTarea tipoDeTarea = _mapper.Map<TipoDeTarea>(tipoDeTareaDto);
                return _repositorio.Existe(tipoDeTarea);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeTareaEditDto GetipoDeTareaPorId(int? id)
        {
            try
            {
                return _repositorio.GetipoDeTareaPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDeTareaListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<TipoDeTareaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public void Guardar(TipoDeTareaEditDto tipoDeTareaDto)
        {
            try
            {
                TipoDeTarea tipoDeTarea = _mapper.Map<TipoDeTarea>(tipoDeTareaDto);
                _repositorio.Guardar(tipoDeTarea);
                _unitOfWork.Save();
                tipoDeTareaDto.TipoDeTareaId = tipoDeTarea.TipoDeTareaId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        
    }
}
