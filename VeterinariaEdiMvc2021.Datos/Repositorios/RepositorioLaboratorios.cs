using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioLaboratorios : IRepositorioLaboratorios
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioLaboratorios(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                var laboratorioInDb = _context.Laboratorios.Find(id);
                _context.Entry(laboratorioInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar los Laboratorios");
            }
        }

        public bool Existe(Laboratorio laboratorio)
        {
            if (laboratorio.LaboratorioId == 0)
            {
                return _context.Laboratorios.Any(la => la.Nombre == laboratorio.Nombre);
            }

            return _context.Laboratorios.Any(la => la.Nombre == laboratorio.Nombre && la.LaboratorioId == laboratorio.LaboratorioId);
        }

        public LaboratorioEditDto GetLaboratorioPorId(int? id)
        {
            try
            {
                return _mapper.Map<LaboratorioEditDto>(_context.Laboratorios.SingleOrDefault(la => la.LaboratorioId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Laboratorios");
            }
        }

        public List<LaboratorioListDto> GetLista()
        {
            try
            {
                var lista= _context.Laboratorios.ToList();
                return _mapper.Map<List<LaboratorioListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Laboratorios");
            }
        }

        public void Guardar(Laboratorio laboratorio)
        {
            try
            {
                if (laboratorio.LaboratorioId == 0)
                {
                    _context.Laboratorios.Add(laboratorio);
                }
                else
                {
                    var laboratorioInDb = _context.Laboratorios.Find(laboratorio.LaboratorioId);
                    laboratorioInDb.Nombre = laboratorio.Nombre;
                    _context.Entry(laboratorioInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar un Laboratorio");
            }
        }
    }
}
