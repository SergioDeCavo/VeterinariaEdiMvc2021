using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosTipoDeMedicamento : IServiciosTipoDeMedicamento
    {
        private readonly IRepositorioTipoDeMedicamentos _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosTipoDeMedicamento(IRepositorioTipoDeMedicamentos repositorio, IUnitOfWork unitOfWork)
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

        public bool Existe(TipoDeMedicamentoEditDto tipoDeMedicamentoDto)
        {
            try
            {
                TipoDeMedicamento tipoDeMedicamento = _mapper.Map<TipoDeMedicamento>(tipoDeMedicamentoDto);
                return _repositorio.Existe(tipoDeMedicamento);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeMedicamentoEditDto GetipoDeMedicamentoPorId(int? id)
        {
            try
            {
                return _repositorio.GetipoDeMedicamentoPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDeMedicamentoListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<TipoDeMedicamentoListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public void Guardar(TipoDeMedicamentoEditDto tipoDeMedicamentoDto)
        {
            try
            {
                TipoDeMedicamento tipoDeMedicamento = _mapper.Map<TipoDeMedicamento>(tipoDeMedicamentoDto);
                _repositorio.Guardar(tipoDeMedicamento);
                _unitOfWork.Save();
                tipoDeMedicamentoDto.TipoDeMedicamentoId = tipoDeMedicamento.TipoDeMedicamentoId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
