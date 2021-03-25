using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioDrogas : IRepositorioDrogas
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioDrogas(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public void Borrar(int? id)
        {
            try
            {
                var drogaInDb = _context.Drogas.Find(id);
                _context.Entry(drogaInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar las Drogas");
            }
        }

        public bool Existe(Droga droga)
        {
            if (droga.DrogaId == 0)
            {
                return _context.Drogas.Any(dr => dr.NombreDroga == droga.NombreDroga);
            }

            return _context.Drogas.Any(dr => dr.NombreDroga == droga.NombreDroga && dr.DrogaId == droga.DrogaId);
        }

        public DrogaEditDto GetDrogaPorId(int? id)
        {
            try
            {
                return _mapper.Map<DrogaEditDto>(_context.Drogas.SingleOrDefault(dr => dr.DrogaId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las Drogas");
            }
        }

        public List<DrogaListDto> GetLista()
        {
            try
            {
                var lista= _context.Drogas.ToList();
                return _mapper.Map<List<DrogaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las Drogas");
            }
        }

        public void Guardar(Droga droga)
        {
            try
            {
                if (droga.DrogaId == 0)
                {
                    _context.Drogas.Add(droga);
                }
                else
                {
                    var drogaInDb = _context.Drogas.Find(droga.DrogaId);
                    drogaInDb.NombreDroga = droga.NombreDroga;
                    _context.Entry(drogaInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar una Droga");
            }
        }
    }
}
