using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosProveedor : IServiciosProveedor
    {
        private readonly IRepositorioProveedores _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosProveedor(IRepositorioProveedores repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int proveedorId)
        {
            try
            {
                _repositorio.Borrar(proveedorId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProveedorEditDto proveedorEditDto)
        {
            try
            {
                Proveedor proveedor = _mapper.Map<Proveedor>(proveedorEditDto);
                return _repositorio.Existe(proveedor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public List<ProveedorListDto> GetLista(string nombreLocalidad)
        {
            try
            {
                return _repositorio.GetLista(nombreLocalidad);
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los Proveedores");
            }

        }

        public ProveedorEditDto GetProveedorPorId(int? id)
        {
            try
            {
                return _repositorio.GetProveedorPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Guardar(ProveedorEditDto proveedorDto)
        {
            try
            {
                Proveedor proveedor = _mapper.Map<Proveedor>(proveedorDto);
                _repositorio.Guardar(proveedor);
                _unitOfWork.Save();
                proveedorDto.ProveedorId = proveedor.ProveedorId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
