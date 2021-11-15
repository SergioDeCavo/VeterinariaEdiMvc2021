using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosRaza : IServiciosRaza
    {
        private readonly IRepositorioRazas _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosRaza(IRepositorioRazas repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int razaId)
        {
            try
            {
                _repositorio.Borrar(razaId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(RazaEditDto razaDto)
        {
            try
            {
                Raza raza = _mapper.Map<Raza>(razaDto);
                return _repositorio.EstaRelacionado(raza);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public bool Existe(RazaEditDto razaEditDto)
        {
            try
            {
                Raza raza = _mapper.Map<Raza>(razaEditDto);
                return _repositorio.Existe(raza);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }
        }

        public List<RazaListDto> GetLista(string tipoDeMascota)
        {
            try
            {
                return _repositorio.GetLista(tipoDeMascota);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Raza> GetLista(int tipoDeMascotaId)
        {
            try
            {
                return _repositorio.GetLista(tipoDeMascotaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Raza> GetLista()
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

        public RazaEditDto GetRazaPorId(int? id)
        {
            try
            {
                return _repositorio.GetRazaPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Guardar(RazaEditDto razaDto)
        {
            try
            {
                Raza raza = _mapper.Map<Raza>(razaDto);
                _repositorio.Guardar(raza);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        
    }
}
