using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using System.Linq;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioLocalidades : IRepositorioLocalidades
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioLocalidades(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int localidadId)
        {
            try
            {
                var localidadInDb = _context.Localidades.SingleOrDefault(l => l.LocalidadId == localidadId);
                if (localidadInDb == null)
                {
                    throw new Exception("Localidad inexistente...");
                }
                _context.Entry(localidadInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {

                throw new Exception("Error al intentar borrar una Localidad...");
            }

        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    return _context.Localidades.Any(p => p.NombreLocalidad == localidad.NombreLocalidad);
                }
                return _context.Localidades.Any(p => p.NombreLocalidad == localidad.NombreLocalidad && p.ProvinciaId == localidad.ProvinciaId && p.LocalidadId != localidad.LocalidadId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe una Localidad");
            }
        }

        public List<LocalidadListDto> GetLista(string nombreProvincia)
        {
            try
            {
                IQueryable<LocalidadListDto> listaDto = _context.Localidades.Include(p => p.Provincia)
                    .Select(p => new LocalidadListDto
                    {
                        LocalidadId = p.LocalidadId,
                        NombreLocalidad = p.NombreLocalidad,
                        Provincia = p.Provincia.NombreProvincia
                    });
                if (nombreProvincia!=null)
                {
                    listaDto = listaDto.Where
                        (p => p.Provincia == nombreProvincia);
                }
                return listaDto.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las Localidades");

            }
        }

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return _mapper.Map<LocalidadEditDto>(_context.Localidades.SingleOrDefault(l => l.LocalidadId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las Localidades");
            }
        }

        public void Guardar(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId==0)
                {
                    _context.Localidades.Add(localidad);
                }
                else
                {
                    var localidadInDb = _context.Localidades.SingleOrDefault(l => l.LocalidadId == localidad.LocalidadId);
                    localidadInDb.LocalidadId = localidad.LocalidadId;
                    localidadInDb.NombreLocalidad = localidad.NombreLocalidad;
                    localidadInDb.ProvinciaId = localidad.ProvinciaId;
                    _context.Entry(localidadInDb).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar una Localidad");

            }
        }
    }
}
