using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosFormaFarmaceutica : IServiciosFormaFarmaceutica
    {
        private readonly IRepositorioFormaFarmaceuticas _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosFormaFarmaceutica(IRepositorioFormaFarmaceuticas repositorio, IUnitOfWork unitOfWork)
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

        public bool Existe(FormaFarmaceuticaEditDto formaFarmaceuticaDto)
        {
            try
            {
                FormaFarmaceutica formaFarmaceutica = _mapper.Map<FormaFarmaceutica>(formaFarmaceuticaDto);
                return _repositorio.Existe(formaFarmaceutica);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public FormaFarmaceuticaEditDto GetFormaFarmaceuticaPorId(int? id)
        {
            try
            {
                return _repositorio.GetFormaFarmaceuticaPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<FormaFarmaceuticaListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<FormaFarmaceuticaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public void Guardar(FormaFarmaceuticaEditDto formaFarmaceuticaDto)
        {
            try
            {
                FormaFarmaceutica formaFarmaceutica = _mapper.Map<FormaFarmaceutica>(formaFarmaceuticaDto);
                _repositorio.Guardar(formaFarmaceutica);
                _unitOfWork.Save();
                formaFarmaceuticaDto.FormaFarmaceuticaId = formaFarmaceutica.FormaFarmaceuticaId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
