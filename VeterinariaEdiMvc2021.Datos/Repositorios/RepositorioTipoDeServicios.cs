using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioTipoDeServicios : IRepositorioTipoDeServicios
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioTipoDeServicios(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public void Borrar(int? id)
        {
            try
            {
                var servicioInDb = _context.TipoDeServicios.Find(id);
                _context.Entry(servicioInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar los Tipos De Servicios");
            }
        }

        //public bool EstaRelacionado(TipoDeServicio tipoDeServicio)
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Error al verificar si està relacionado un Tipo de Servicio");
        //    }
        //}

        public bool Existe(TipoDeServicio tipoDeServicio)
        {
            try
            {
                if (tipoDeServicio.TipoDeServicioId == 0)
                {
                    return _context.TipoDeServicios.Any(ts => ts.Descripcion == tipoDeServicio.Descripcion);
                }

                return _context.TipoDeServicios.Any(ts => ts.Descripcion == tipoDeServicio.Descripcion && ts.TipoDeServicioId == tipoDeServicio.TipoDeServicioId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe un Tipo de Servicio");
            }
        }

        public TipoDeServicioEditDto GetipoDeServicioPorId(int? id)
        {
            try
            {
                return _mapper.Map<TipoDeServicioEditDto>(_context.TipoDeServicios.SingleOrDefault(ts => ts.TipoDeServicioId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Servicios");
            }
        }

        public List<TipoDeServicioListDto> GetLista()
        {
            try
            {
                var lista= _context.TipoDeServicios.ToList();
                return _mapper.Map<List<TipoDeServicioListDto>>(lista);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar leer los Tipos de Servicios");
            }
        }

        public void Guardar(TipoDeServicio tipoDeServicio)
        {
            try
            {
                if (tipoDeServicio.TipoDeServicioId == 0)
                {
                    _context.TipoDeServicios.Add(tipoDeServicio);
                }
                else
                {
                    var servicioInDb = _context.TipoDeServicios.Find(tipoDeServicio.TipoDeServicioId);
                    servicioInDb.Descripcion = tipoDeServicio.Descripcion;
                    _context.Entry(servicioInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar un Tipo De Servicio");
            }
        }

    }
}
