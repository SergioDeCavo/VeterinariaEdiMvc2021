using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioProveedores(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int proveedorId)
        {
            try
            {
                var proveedorInDb = _context.Proveedores.SingleOrDefault(p => p.ProveedorId == proveedorId);
                if (proveedorInDb == null)
                {
                    throw new Exception("Proveedor inexistente...");
                }
                _context.Entry(proveedorInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un Proveedor");
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                if (proveedor.ProveedorId == 0)
                {
                    return _context.Proveedores.Any(p => p.CUIT == proveedor.CUIT);
                }
                return _context.Proveedores.Any(p => p.CUIT == proveedor.CUIT && p.ProveedorId != proveedor.ProveedorId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe un Proveedor");
            }

        }

        public List<ProveedorListDto> GetLista(string nombreLocalidad)
        {
            try
            {
                IQueryable<ProveedorListDto> listaDto = _context.Proveedores.Include(p => p.Provincia).Include(p => p.Localidad)
                    .Select(p => new ProveedorListDto

                    {
                    ProveedorId = p.ProveedorId,
                    CUIT= p.CUIT,
                    RazonSocial = p.RazonSocial,
                    Direccion= p.Direccion,
                    TelefonoMovil = p.TelefonoMovil,
                    Localidad = p.Localidad.NombreLocalidad
                });
                if (nombreLocalidad != null)
                {
                    listaDto = listaDto.Where
                        (p => p.Localidad == nombreLocalidad);
                }
                return listaDto.ToList();
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
                return _mapper.Map<ProveedorEditDto>(_context.Proveedores.SingleOrDefault(p => p.ProveedorId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un Proveedor");
            }
        }

        public void Guardar(Proveedor proveedor)
        {
            try
            {
                if (proveedor.ProveedorId == 0)
                {
                    _context.Proveedores.Add(proveedor);
                }
                else
                {
                    var proveedorInDb = _context.Proveedores.SingleOrDefault(p => p.ProveedorId == proveedor.ProveedorId);
                    proveedorInDb.ProveedorId = proveedor.ProveedorId;
                    proveedorInDb.CUIT = proveedor.CUIT;
                    proveedorInDb.RazonSocial= proveedor.RazonSocial;
                    proveedorInDb.PersonaDeContacto = proveedor.PersonaDeContacto;
                    proveedorInDb.Direccion = proveedor.Direccion;
                    proveedorInDb.LocalidadId = proveedor.LocalidadId;
                    proveedorInDb.ProvinciaId = proveedor.ProvinciaId;
                    proveedorInDb.TelefonoFijo = proveedor.TelefonoFijo;
                    proveedorInDb.TelefonoMovil = proveedor.TelefonoMovil;
                    proveedorInDb.CorreoElectronico = proveedor.CorreoElectronico;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar Guardar los Proveedores");
            }
        }
    }
}
