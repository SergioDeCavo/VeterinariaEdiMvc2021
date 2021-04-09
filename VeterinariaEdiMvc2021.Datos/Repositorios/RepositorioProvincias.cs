using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioProvincias : IRepositorioProvincias
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioProvincias(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public void Borrar(int? id)
        {
            try
            {
                var provinciaInDb = _context.Provincias.Find(id);
                _context.Entry(provinciaInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar las Provincias");
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                return _context.Localidades.Any(l => l.ProvinciaId == provincia.ProvinciaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si està relacionado con una Provincia");
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                if (provincia.ProvinciaId == 0)
                {
                    return _context.Provincias.Any(pr => pr.NombreProvincia == provincia.NombreProvincia);
                }

                return _context.Provincias.Any(pr => pr.NombreProvincia == provincia.NombreProvincia && pr.ProvinciaId == provincia.ProvinciaId);

            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe una Provincia");
            }       
        }

        public List<ProvinciaListDto> GetLista()
        {
            try
            {
                var lista= _context.Provincias.ToList();
                return _mapper.Map<List<ProvinciaListDto>>(lista);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar leer las Provincias");
            }
        }

        public ProvinciaEditDto GetProvinciaPorId(int? id)
        {
            try
            {
                return _mapper.Map<ProvinciaEditDto>(_context.Provincias.SingleOrDefault(pr => pr.ProvinciaId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las Provincias");
            }
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                if (provincia.ProvinciaId == 0)
                {
                    _context.Provincias.Add(provincia);
                }
                else
                {
                    var provinciaInDb = _context.Provincias.Find(provincia.ProvinciaId);
                    provinciaInDb.NombreProvincia = provincia.NombreProvincia;
                    _context.Entry(provinciaInDb).State = EntityState.Modified;
                }

                //context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar una Provincia");
            }
        }
    }
}
