using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosDroga : IServiciosDroga
    {
        private readonly IRepositorioDrogas _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosDroga(IRepositorioDrogas repositorio, IUnitOfWork unitOfWork)
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

        public bool Existe(DrogaEditDto drogaDto)
        {
            try
            {
                Droga droga = _mapper.Map<Droga>(drogaDto);
                return _repositorio.Existe(droga);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public DrogaEditDto GetDrogaPorId(int? id)
        {
            try
            {
                return _repositorio.GetDrogaPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<DrogaListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<DrogaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public void Guardar(DrogaEditDto drogaDto)
        {
            try
            {
                Droga droga = _mapper.Map<Droga>(drogaDto);
                _repositorio.Guardar(droga);
                _unitOfWork.Save();
                drogaDto.DrogaId = droga.DrogaId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
