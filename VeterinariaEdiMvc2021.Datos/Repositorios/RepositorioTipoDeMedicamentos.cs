using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioTipoDeMedicamentos : IRepositorioTipoDeMedicamentos
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioTipoDeMedicamentos(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public void Borrar(int? id)
        {
            try
            {
                var medicamentoInDb = _context.TipoDeMedicamentos.Find(id);
                _context.Entry(medicamentoInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar los Tipos De Medicamentos");
            }
        }

        public bool EstaRelacionado(TipoDeMedicamento tipoDeMedicamento)
        {
            try
            {
                return _context.Medicamentos.Any(tm => tm.TipoDeMedicamentoId == tipoDeMedicamento.TipoDeMedicamentoId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si està relacionado un Tipo de Medicamento");
            }
        }

        public bool Existe(TipoDeMedicamento tipoDeMedicamento)
        {
            try
            {
                if (tipoDeMedicamento.TipoDeMedicamentoId == 0)
                {
                    return _context.TipoDeMedicamentos.Any(tme => tme.Descripcion == tipoDeMedicamento.Descripcion);
                }

                return _context.TipoDeMedicamentos.Any(tme => tme.Descripcion == tipoDeMedicamento.Descripcion && tme.TipoDeMedicamentoId == tipoDeMedicamento.TipoDeMedicamentoId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe un Tipo de Medicamento");
            }
        }

        public TipoDeMedicamentoEditDto GetipoDeMedicamentoPorId(int? id)
        {
            try
            {
                return _mapper.Map<TipoDeMedicamentoEditDto>(_context.TipoDeMedicamentos.SingleOrDefault(tme => tme.TipoDeMedicamentoId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Medicamentos");
            }
        }

        public List<TipoDeMedicamentoListDto> GetLista()
        {
            try
            {
                var lista= _context.TipoDeMedicamentos.ToList();
                return _mapper.Map<List<TipoDeMedicamentoListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Medicamentos");
            }
        }

        public void Guardar(TipoDeMedicamento tipoDeMedicamento)
        {
            try
            {
                if (tipoDeMedicamento.TipoDeMedicamentoId == 0)
                {
                    _context.TipoDeMedicamentos.Add(tipoDeMedicamento);
                }
                else
                {
                    var medicamentoInDb = _context.TipoDeMedicamentos.Find(tipoDeMedicamento.TipoDeMedicamentoId);
                    medicamentoInDb.Descripcion = tipoDeMedicamento.Descripcion;
                    _context.Entry(medicamentoInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar un Tipo De Medicamento");
            }
        }
    }
}
