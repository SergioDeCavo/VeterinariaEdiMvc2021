using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosCliente : IServiciosCliente
    {
        private readonly IRepositorioClientes _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosCliente(IRepositorioClientes repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int clienteId)
        {
            try
            {
                _repositorio.Borrar(clienteId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ClienteEditDto clienteEditDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteEditDto);
                return _repositorio.Existe(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public ClienteEditDto GetClientePorId(int? id)
        {
            try
            {
                return _repositorio.GetClientePorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public List<ClienteListDto> GetLista(string nombreProvincia)
        {
            try
            {
                return _repositorio.GetLista(nombreProvincia);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(ClienteEditDto clienteDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                _repositorio.Guardar(cliente);
                _unitOfWork.Save();
                clienteDto.ClienteId = cliente.ClienteId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
