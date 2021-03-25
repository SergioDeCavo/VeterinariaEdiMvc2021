using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioTipoDeMascotas : IRepositorioTipoDeMascotas
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioTipoDeMascotas(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public void Borrar(int? id)
        {
            try
            {
                var mascotaInDb = _context.TipoDeMascotas.Find(id);
                _context.Entry(mascotaInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar los Tipos De Mascotas");
            }
        }

        public bool EstaRelacionado(TipoDeMascota tipoDeMascota)
        {
            try
            {
                return _context.Razas.Any(r => r.TipoDeMascotaId == tipoDeMascota.TipoDeMascotaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si està relacionado con una Raza");
            }
        }

        public bool Existe(TipoDeMascota tipoDeMascota)
        {
            try
            {
                if (tipoDeMascota.TipoDeMascotaId == 0)
                {
                    return _context.TipoDeMascotas.Any(tm => tm.Descripcion == tipoDeMascota.Descripcion);
                }

                return _context.TipoDeMascotas.Any(tm => tm.Descripcion == tipoDeMascota.Descripcion && tm.TipoDeMascotaId == tipoDeMascota.TipoDeMascotaId);

            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe un Tipo de Mascota");
            }        
        }

        public TipoDeMascotaEditDto GetipoDeMascotaPorId(int? id)
        {
            try
            {
                return _mapper.Map<TipoDeMascotaEditDto>(_context.TipoDeMascotas.SingleOrDefault(tm => tm.TipoDeMascotaId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Mascotas");
            }
        }

        public List<TipoDeMascotaListDto> GetLista()
        {
            try
            {
                var lista= _context.TipoDeMascotas.ToList();
                return _mapper.Map<List<TipoDeMascotaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Mascotas");
            }
        }

        public void Guardar(TipoDeMascota tipoDeMascota)
        {
            try
            {
                if (tipoDeMascota.TipoDeMascotaId == 0)
                {
                    _context.TipoDeMascotas.Add(tipoDeMascota);
                }
                else
                {
                    var mascotaInDb = _context.TipoDeMascotas.Find(tipoDeMascota.TipoDeMascotaId);
                    mascotaInDb.Descripcion = tipoDeMascota.Descripcion;
                    _context.Entry(mascotaInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar un Tipo De Mascota");
            }
        }
    }
}
