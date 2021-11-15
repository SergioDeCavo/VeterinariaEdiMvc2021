using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioMedicamentos : IRepositorioMedicamentos
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioMedicamentos(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void ActualizarStock(int medicamentoId, int cantidad)
        {
            try
            {
                var medicamentoInDb = _context.Medicamentos.SingleOrDefault(p => p.MedicamentoId == medicamentoId);
                //medicamentoInDb.UnidadesEnPedido -= cantidad;
                medicamentoInDb.UnidadesEnStock -= cantidad;
                _context.Entry(medicamentoInDb).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int medicamentoId)
        {
            try
            {
                var medicamentoInDb = _context.Medicamentos.SingleOrDefault(me => me.MedicamentoId == medicamentoId);
                if (medicamentoInDb == null)
                {
                    throw new Exception("Medicamento inexistente...");
                }
                _context.Entry(medicamentoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un Medicamento");
            }
        }

        public bool Existe(Medicamento medicamento)
        {
            try
            {
                if (medicamento.MedicamentoId == 0)
                {
                    return _context.Medicamentos.Any(me => me.NombreComercial == medicamento.NombreComercial);
                }
                return _context.Medicamentos.Any(me => me.NombreComercial == medicamento.NombreComercial && me.MedicamentoId != medicamento.MedicamentoId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe un Medicamento");
            }

        }

        public List<MedicamentoListDto> GetLista(string tipoDeMedicamento)
        {
            try
            {
                IQueryable<MedicamentoListDto> listaDto = _context.Medicamentos.Include(me => me.TipoDeMedicamento)
                    .Select(me => new MedicamentoListDto

                    {
                        MedicamentoId = me.MedicamentoId,
                        NombreComercial = me.NombreComercial,
                        TipoDeMedicamento = me.TipoDeMedicamento.Descripcion,
                        FormaFarmaceutica = me.FormaFarmaceutica.Descripcion,
                        Laboratorio = me.Laboratorio.Nombre,
                        PrecioVenta = me.PrecioVenta,
                        Suspendido = me.Suspendido
                    });
                if (tipoDeMedicamento != null)
                {
                    listaDto = listaDto.Where(p => p.TipoDeMedicamento == tipoDeMedicamento);
                }
                return listaDto.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los Medicamentos");
            }
        }

        public List<Medicamento> GetLista(int tipoDeMedicamentoId)
        {
            try
            {
                return _context.Medicamentos.Where(c => c.TipoDeMedicamentoId == tipoDeMedicamentoId)
                    .OrderBy(c => c.NombreComercial)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar leer la tabla de Medicamentos");
            }
        }

        public List<Medicamento> GetLista()
        {
            try
            {
                return _context.Medicamentos.Include(c => c.TipoDeMedicamentoId)
                    .OrderBy(c => c.NombreComercial)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar leer la tabla de Medicamentos");
            }
        }

        public MedicamentoEditDto GetMedicamentoPorId(int? id)
        {
            try
            {
                return _mapper.Map<MedicamentoEditDto>(_context.Medicamentos.SingleOrDefault(me => me.MedicamentoId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un Medicamento");
            }
        }

        public Medicamento GetTMedPorId(int id)
        {
            try
            {
                return _mapper.Map<Medicamento>(_context.Medicamentos.SingleOrDefault(me => me.MedicamentoId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un Medicamento");
            }
        }

        public void Guardar(Medicamento medicamento)
        {
            try
            {
                if (medicamento.MedicamentoId == 0)
                {
                    _context.Medicamentos.Add(medicamento);
                }
                else
                {
                    var medicamentoInDb = _context.Medicamentos.SingleOrDefault(me => me.MedicamentoId == medicamento.MedicamentoId);
                    medicamentoInDb.MedicamentoId = medicamento.MedicamentoId;
                    medicamentoInDb.NombreComercial = medicamento.NombreComercial;
                    medicamentoInDb.TipoDeMedicamentoId = medicamento.TipoDeMedicamentoId;
                    medicamentoInDb.FormaFarmaceuticaId = medicamento.FormaFarmaceuticaId;
                    medicamentoInDb.LaboratorioId = medicamento.LaboratorioId;
                    medicamentoInDb.PrecioVenta = medicamento.PrecioVenta;
                    medicamentoInDb.UnidadesEnStock = medicamento.UnidadesEnStock;
                    medicamentoInDb.NivelDeReposicion = medicamento.NivelDeReposicion;
                    medicamentoInDb.CantidadesPorUnidad = medicamento.CantidadesPorUnidad;
                    medicamentoInDb.Suspendido= medicamento.Suspendido;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar Guardar los Mediamentos");
            }
        }

        public void SetearReservarProducto(int medicamentoId, int cantidad)
        {
            try
            {
                var medicamentoInDb = _context.Medicamentos.SingleOrDefault(p => p.MedicamentoId == medicamentoId);
                medicamentoInDb.UnidadesEnStock += cantidad;
                _context.Entry(medicamentoInDb).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                throw new Exception("Error al guardar");
            }
        }
    }
}
