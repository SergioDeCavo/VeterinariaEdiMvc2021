using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioTipoDeTareas : IRepositorioTipoDeTareas
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioTipoDeTareas(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public void Borrar(int? id)
        {
            try
            {
                var tareaInDb = _context.TipoDeTareas.Find(id);
                _context.Entry(tareaInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar los Tipos De Tareas");
            }
        }

        public bool EstaRelacionado(TipoDeTarea tipoDeTarea)
        {
            try
            {
                return _context.Empleados.Any(tt => tt.TipoDeTareaId == tipoDeTarea.TipoDeTareaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si està relacionado un Tipo de Tarea");
            }
        }

        public bool Existe(TipoDeTarea tipoDeTarea)
        {
            try
            {
                if (tipoDeTarea.TipoDeTareaId == 0)
                {
                    return _context.TipoDeTareas.Any(tt => tt.Descripcion == tipoDeTarea.Descripcion);
                }

                return _context.TipoDeTareas.Any(tt => tt.Descripcion == tipoDeTarea.Descripcion && tt.TipoDeTareaId == tipoDeTarea.TipoDeTareaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe un Tipo de Tarea");
            }
        }

        public TipoDeTareaEditDto GetipoDeTareaPorId(int? id)
        {
            try
            {
                return _mapper.Map<TipoDeTareaEditDto>(_context.TipoDeTareas.SingleOrDefault(tt => tt.TipoDeTareaId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Tareas");
            }
        }

        public List<TipoDeTareaListDto> GetLista()
        {
            try
            {
                var lista= _context.TipoDeTareas.ToList();
                return _mapper.Map<List<TipoDeTareaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Tareas");
            }
        }

        public void Guardar(TipoDeTarea tipoDeTarea)
        {
            try
            {
                if (tipoDeTarea.TipoDeTareaId==0)
                {
                    _context.TipoDeTareas.Add(tipoDeTarea);
                }
                else
                {
                    var tareaInDb = _context.TipoDeTareas.Find(tipoDeTarea.TipoDeTareaId);
                    tareaInDb.Descripcion = tipoDeTarea.Descripcion;
                    _context.Entry(tareaInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar un Tipo De Tarea");
            }
        }

    }
}
