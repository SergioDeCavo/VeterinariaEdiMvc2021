﻿using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using System.Linq;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioRazas : IRepositorioRazas
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioRazas(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int razaId)
        {
            try
            {
                var razaInDb = _context.Razas.SingleOrDefault(r => r.RazaId == razaId);
                if (razaInDb==null)
                {
                    throw new Exception("Raza inexistente...");
                }
                _context.Entry(razaInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {

                throw new Exception("Error al intentar borrar una Raza...");
            }
            
            
        }

        public bool EstaRelacionado(Raza raza)
        {
            try
            {
                return _context.Mascotas.Any(r => r.RazaId == raza.RazaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si està relacionada una Raza");
            }
        }

        public bool Existe(Raza raza)
        {
            try
            {
                if (raza.RazaId == 0)
                {
                    return _context.Razas.Any(p => p.Descripcion == raza.Descripcion);
                }
                return _context.Razas.Any(p => p.Descripcion == raza.Descripcion && p.TipoDeMascotaId == raza.TipoDeMascotaId && p.RazaId != raza.RazaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe una Raza");
            }
        }

        public List<RazaListDto> GetLista(string tipoDeMascota)
        {
            try
            {
                IQueryable<RazaListDto> listaDto = _context.Razas.Include(p => p.TipoDeMascota)
                    .Select(p => new RazaListDto
                {
                    RazaId = p.RazaId,
                    Descripcion = p.Descripcion,
                    TipoDeMascota = p.TipoDeMascota.Descripcion

                });
                if (tipoDeMascota!=null)
                {
                    listaDto = listaDto.Where(p => p.TipoDeMascota == tipoDeMascota);
                    
                    
                }
                return listaDto.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer las Razas");
                
            }
        }

        public List<Raza> GetLista(int tipoDeMascotaId)
        {
            try
            {
                return _context.Razas.Where(c => c.TipoDeMascotaId == tipoDeMascotaId)
                    .OrderBy(c => c.Descripcion)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar leer la tabla de Razas");
            }
        }

        public List<Raza> GetLista()
        {
            try
            {
                return _context.Razas.Include(p => p.TipoDeMascota)
                    .OrderBy(c => c.Descripcion).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public RazaEditDto GetRazaPorId(int? id)
        {
            try
            {
                return _mapper.Map<RazaEditDto>(_context.Razas.SingleOrDefault(l => l.RazaId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las Razas");
            }
        }

        public void Guardar(Raza raza)
        {
            try
            {
                if (raza.RazaId == 0)
                {
                    _context.Razas.Add(raza);
                }
                else
                {
                    var razaInDb = _context.Razas.SingleOrDefault(r => r.RazaId == raza.RazaId);
                    razaInDb.RazaId = raza.RazaId;
                    razaInDb.Descripcion = raza.Descripcion;
                    razaInDb.TipoDeMascotaId = raza.TipoDeMascotaId;
                    _context.Entry(razaInDb).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar una Raza");

            }
        }
    }
}
