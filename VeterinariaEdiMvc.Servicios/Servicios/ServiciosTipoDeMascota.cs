using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosTipoDeMascota : IServiciosTipoDeMascota
    {
        private readonly IRepositorioTipoDeMascotas _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosTipoDeMascota(IRepositorioTipoDeMascotas repositorio, IUnitOfWork unitOfWork)
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

        public bool EstaRelacionado(TipoDeMascotaEditDto tipoMasDto)
        {
            try
            {
                TipoDeMascota tipoDeMascota = _mapper.Map<TipoDeMascota>(tipoMasDto);
                return _repositorio.EstaRelacionado(tipoDeMascota);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeMascotaEditDto tipoDeMascotaDto)
        {
            try
            {
                TipoDeMascota tipoDeMascota = _mapper.Map<TipoDeMascota>(tipoDeMascotaDto);
                return _repositorio.Existe(tipoDeMascota);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeMascotaEditDto GetipoDeMascotaPorId(int? id)
        {
            try
            {
                return _repositorio.GetipoDeMascotaPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDeMascotaListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<TipoDeMascotaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
        }

        public void Guardar(TipoDeMascotaEditDto tipoDeMascotaDto)
        {
            try
            {
                TipoDeMascota tipoDeMascota = _mapper.Map<TipoDeMascota>(tipoDeMascotaDto);
                _repositorio.Guardar(tipoDeMascota);
                _unitOfWork.Save();
                tipoDeMascotaDto.TipoDeMascotaId = tipoDeMascota.TipoDeMascotaId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
