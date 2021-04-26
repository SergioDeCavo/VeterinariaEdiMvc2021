using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosLaboratorio : IServiciosLaboratorio
    {
        private readonly IRepositorioLaboratorios _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosLaboratorio(IRepositorioLaboratorios repositorio, IUnitOfWork unitOfWork)
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

        public bool EstaRelacionado(LaboratorioEditDto laboratorioDto)
        {
            try
            {
                Laboratorio laboratorio = _mapper.Map<Laboratorio>(laboratorioDto);
                return _repositorio.EstaRelacionado(laboratorio);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(LaboratorioEditDto laboratorioDto)
        {
            try
            {
                Laboratorio laboratorio = _mapper.Map<Laboratorio>(laboratorioDto);
                return _repositorio.Existe(laboratorio);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public LaboratorioEditDto GetLaboratorioPorId(int? id)
        {
            try
            {
                return _repositorio.GetLaboratorioPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<LaboratorioListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<LaboratorioListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public void Guardar(LaboratorioEditDto laboratorioDto)
        {
            try
            {
                Laboratorio laboratorio = _mapper.Map<Laboratorio>(laboratorioDto);
                _repositorio.Guardar(laboratorio);
                _unitOfWork.Save();
                laboratorioDto.LaboratorioId = laboratorio.LaboratorioId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
