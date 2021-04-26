using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioFormaFarmaceuticas : IRepositorioFormaFarmaceuticas
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioFormaFarmaceuticas(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public void Borrar(int? id)
        {
            try
            {
                var formaFarmaceuticaInDb = _context.FormaFarmaceuticas.Find(id);
                _context.Entry(formaFarmaceuticaInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar las Formas Farmacèuticas");
            }
        }

        public bool EstaRelacionado(FormaFarmaceutica formaFarmaceutica)
        {
            try
            {
                return _context.Medicamentos.Any(f => f.FormaFarmaceuticaId == formaFarmaceutica.FormaFarmaceuticaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si està relacionada una Forma Farmacèutica");
            }
        }

        public bool Existe(FormaFarmaceutica formaFarmaceutica)
        {
            try
            {
                if (formaFarmaceutica.FormaFarmaceuticaId == 0)
                {
                    return _context.FormaFarmaceuticas.Any(ff => ff.Descripcion == formaFarmaceutica.Descripcion);
                }

                return _context.FormaFarmaceuticas.Any(ff => ff.Descripcion == formaFarmaceutica.Descripcion && ff.FormaFarmaceuticaId == formaFarmaceutica.FormaFarmaceuticaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe una Forma Farmacèutica");
            }
        }

        public FormaFarmaceuticaEditDto GetFormaFarmaceuticaPorId(int? id)
        {
            try
            {
                return _mapper.Map<FormaFarmaceuticaEditDto>(_context.FormaFarmaceuticas.SingleOrDefault(ff => ff.FormaFarmaceuticaId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las Formas Farmacèuticas");
            }
        }

        public List<FormaFarmaceuticaListDto> GetLista()
        {
            try
            {
                var lista= _context.FormaFarmaceuticas.ToList();
                return _mapper.Map<List<FormaFarmaceuticaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las Formas Farmacèuticas");
            }
        }

        public void Guardar(FormaFarmaceutica formaFarmaceutica)
        {
            try
            {
                if (formaFarmaceutica.FormaFarmaceuticaId == 0)
                {
                    _context.FormaFarmaceuticas.Add(formaFarmaceutica);
                }
                else
                {
                    var formaFarmaceuticaInDb = _context.FormaFarmaceuticas.Find(formaFarmaceutica.FormaFarmaceuticaId);
                    formaFarmaceuticaInDb.Descripcion = formaFarmaceutica.Descripcion;
                    _context.Entry(formaFarmaceuticaInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar una Forma Farmacèutica");
            }
        }
    }
}
