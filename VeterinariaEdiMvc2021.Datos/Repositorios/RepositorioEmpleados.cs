using AutoMapper;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Empleado;
using System.Data.Entity;
using System.Linq;
using System;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioEmpleados : IRepositorioEmpleados
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioEmpleados(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int empleadoId)
        {
            try
            {
                var empleadoInDb = _context.Empleados.SingleOrDefault(e => e.EmpleadoId == empleadoId);
                if (empleadoInDb == null)
                {
                    throw new Exception("Empleado inexistente...");
                }
                _context.Entry(empleadoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un Empleado");
            }
        }

        public bool Existe(Empleado empleado)
        {
            if (empleado.EmpleadoId == 0)
            {
                return _context.Empleados.Any(e => e.NumeroDocumento == empleado.NumeroDocumento);
            }
            return _context.Empleados.Any(e => e.NumeroDocumento == empleado.NumeroDocumento && e.EmpleadoId != empleado.EmpleadoId);

        }

        public EmpleadoEditDto GetEmpleadoPorId(int? id)
        {
            try
            {
                return _mapper.Map<EmpleadoEditDto>(_context.Empleados.SingleOrDefault(e => e.EmpleadoId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un Empleado");
            }
        }

        public List<EmpleadoListDto> GetLista(string nombreTarea)
        {
            try
            {
                IQueryable<EmpleadoListDto> listaDto = _context.Empleados.Include(e => e.TipoDeTarea)
                    .Select(e => new EmpleadoListDto

                {
                    EmpleadoId = e.EmpleadoId,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    TipoDeTarea = e.TipoDeTarea.Descripcion,
                    Direccion = e.Direccion,
                    TelefonoMovil = e.TelefonoMovil,
                    Localidad = e.Localidad.NombreLocalidad
                });
                if (nombreTarea != null)
                {
                    listaDto = listaDto.Where
                        (e => e.TipoDeTarea == nombreTarea);
                }
                return listaDto.ToList();
            }
            catch (Exception )
            {
                throw new Exception("Error al intentar leer los Empleados");

            }
        }

        public void Guardar(Empleado empleado)
        {
            try
            {
                if (empleado.EmpleadoId == 0)
                {
                    _context.Empleados.Add(empleado);
                }
                else
                {
                    var empleadoInDb = _context.Empleados.SingleOrDefault(c => c.EmpleadoId == empleado.EmpleadoId);
                    empleadoInDb.EmpleadoId = empleado.EmpleadoId;
                    empleadoInDb.Nombre = empleado.Nombre;
                    empleadoInDb.Apellido = empleado.Apellido;
                    empleadoInDb.TipoDeDocumentoId = empleado.TipoDeDocumentoId;
                    empleadoInDb.NumeroDocumento = empleado.NumeroDocumento;
                    empleadoInDb.Direccion = empleado.Direccion;
                    empleadoInDb.LocalidadId = empleado.LocalidadId;
                    empleadoInDb.ProvinciaId = empleado.ProvinciaId;
                    empleadoInDb.TelefonoFijo = empleado.TelefonoFijo;
                    empleadoInDb.TelefonoMovil = empleado.TelefonoMovil;
                    empleadoInDb.CorreoElectronico = empleado.CorreoElectronico;
                    empleadoInDb.TipoDeTareaId = empleado.TipoDeTareaId;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar Guardar los Empleados");
            }
        }
    }
}
