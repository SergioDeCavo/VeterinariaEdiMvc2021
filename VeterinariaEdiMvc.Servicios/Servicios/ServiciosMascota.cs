using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Mascota;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosMascota : IServiciosMascota
    {
        private readonly IRepositorioMascotas _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosMascota(IRepositorioMascotas repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int mascotaId)
        {
            try
            {
                _repositorio.Borrar(mascotaId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(MascotaEditDto mascotaEditDto)
        {
            try
            {
                Mascota mascota = _mapper.Map<Mascota>(mascotaEditDto);
                return _repositorio.Existe(mascota);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public List<MascotaListDto> GetLista(string tipoDeMascota)
        {
            try
            {
                return _repositorio.GetLista(tipoDeMascota);
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las Mascotas");
            }
        }

        public List<Mascota> GetLista(int tipoDeMascotaId)
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

        public List<Mascota> GetLista()
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

        public MascotaEditDto GetMascotaPorId(int? id)
        {
            try
            {
                return _repositorio.GetMascotaPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Guardar(MascotaEditDto mascotaDto)
        {
            try
            {
                Mascota mascota = _mapper.Map<Mascota>(mascotaDto);
                _repositorio.Guardar(mascota);
                _unitOfWork.Save();
                mascotaDto.MascotaId = mascota.MascotaId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
