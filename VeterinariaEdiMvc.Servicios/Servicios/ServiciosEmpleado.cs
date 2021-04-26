using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Empleado;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosEmpleado : IServiciosEmpleado
    {
        private readonly IRepositorioEmpleados _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosEmpleado(IRepositorioEmpleados repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int empleadoId)
        {
            try
            {
                _repositorio.Borrar(empleadoId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(EmpleadoEditDto empleadoEditDto)
        {
            try
            {
                Empleado empleado = _mapper.Map<Empleado>(empleadoEditDto);
                return _repositorio.Existe(empleado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public EmpleadoEditDto GetEmpleadoPorId(int? id)
        {
            try
            {
                return _repositorio.GetEmpleadoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public List<EmpleadoListDto> GetLista(string nombreTarea)
        {
            try
            {
                return _repositorio.GetLista(nombreTarea);
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los Empleados");
            }
        }

        public void Guardar(EmpleadoEditDto empleadoDto)
        {
            try
            {
                Empleado empleado = _mapper.Map<Empleado>(empleadoDto);
                _repositorio.Guardar(empleado);
                _unitOfWork.Save();
                empleadoDto.EmpleadoId = empleado.EmpleadoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
