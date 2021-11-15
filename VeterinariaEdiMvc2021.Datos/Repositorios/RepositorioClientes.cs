using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioClientes(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int clienteId)
        {
            try
            {
                var clienteInDb = _context.Clientes.SingleOrDefault(c => c.ClienteId == clienteId);
                if (clienteInDb==null)
                {
                    throw new Exception("Cliente inexistente...");
                }
                _context.Entry(clienteInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un Cliente");
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    return _context.Clientes.Any(c => c.NumeroDocumento == cliente.NumeroDocumento);
                }
                return _context.Clientes.Any(c => c.NumeroDocumento == cliente.NumeroDocumento && c.ClienteId != cliente.ClienteId);

            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe un Cliente");
            }
        }

        public ClienteEditDto GetClientePorId(int? id)
        {
            try
            {
                return _mapper.Map<ClienteEditDto>(_context.Clientes.Include(c=>c.Provincia).Include(c=>c.Localidad).SingleOrDefault(c => c.ClienteId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un Cliente");
            }       
        }

        public List<ClienteListDto> GetLista(string nombreProvincia)
        {
            try
            {
                IQueryable<ClienteListDto> listaDto = _context.Clientes.Include(c => c.Provincia)
                    .Select(c => new ClienteListDto
                    {
                    ClienteId = c.ClienteId,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Direccion = c.Direccion,
                    Provincia = c.Provincia.NombreProvincia,
                    Localidad = c.Localidad.NombreLocalidad,
                    TelefonoFijo = c.TelefonoFijo,
                    TelefonoMovil = c.TelefonoMovil,
                    CorreoElectronico = c.CorreoElectronico
                });
                if (nombreProvincia != null)
                {
                    listaDto = listaDto.Where
                        (c => c.Provincia == nombreProvincia);
                }
                return listaDto.ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Clientes");
            }        
        }

        public List<Cliente> GetLista(int localidadId)
        {
            try
            {
                return _context.Clientes.Where(c => c.LocalidadId == localidadId)
                    .OrderBy(c => c.Apellido)
                    .ThenBy(c => c.Nombre)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar leer la tabla de Clientes");
            }
        }

        public List<Cliente> GetLista()
        {
            try
            {
                return _context.Clientes.Include(p => p.Provincia).Include(p => p.Localidad)
                    .OrderBy(c => c.Apellido).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId==0)
                {
                    _context.Clientes.Add(cliente);
                }
                else
                {
                    var clienteInDb = _context.Clientes.SingleOrDefault(c => c.ClienteId == cliente.ClienteId);
                    clienteInDb.ClienteId = cliente.ClienteId;
                    clienteInDb.Nombre = cliente.Nombre;
                    clienteInDb.Apellido = cliente.Apellido;
                    clienteInDb.TipoDeDocumentoId = cliente.TipoDeDocumentoId;
                    clienteInDb.NumeroDocumento = cliente.NumeroDocumento;
                    clienteInDb.Direccion = cliente.Direccion;
                    clienteInDb.LocalidadId = cliente.LocalidadId;
                    clienteInDb.ProvinciaId = cliente.ProvinciaId;
                    clienteInDb.TelefonoFijo = cliente.TelefonoFijo;
                    clienteInDb.TelefonoMovil = cliente.TelefonoMovil;
                    clienteInDb.CorreoElectronico = cliente.CorreoElectronico;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar Guardar los Clientes");
            }
        }
    }
}
