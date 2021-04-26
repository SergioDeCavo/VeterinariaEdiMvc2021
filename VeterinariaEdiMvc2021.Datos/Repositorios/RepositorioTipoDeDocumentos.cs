using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioTipoDeDocumentos : IRepositorioTipoDeDocumentos
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioTipoDeDocumentos(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public void Borrar(int? id)
        {
            try
            {
                var documentoInDb = _context.TipoDeDocumentos.Find(id);
                _context.Entry(documentoInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Borrar los Tipos De Documentos");
            }
        }

        public bool EstaRelacionado(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                return _context.Clientes.Any(td => td.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId);
                //return _context.Empleados.Any(td => td.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si està relacionado un Tipo de Documento");
            }
        }

        public bool Existe(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                if (tipoDeDocumento.TipoDeDocumentoId == 0)
                {
                    return _context.TipoDeDocumentos.Any(td => td.Descripcion == tipoDeDocumento.Descripcion);
                }

                return _context.TipoDeDocumentos.Any(td => td.Descripcion == tipoDeDocumento.Descripcion && td.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe un Tipo de Documento");
            }
        }

        public TipoDeDocumentoEditDto GetipoDeDocumentoPorId(int? id)
        {
            try
            {
                return _mapper.Map<TipoDeDocumentoEditDto>(_context.TipoDeDocumentos.SingleOrDefault(td => td.TipoDeDocumentoId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Documentos");
            }
        }

        public List<TipoDeDocumentoListDto> GetLista()
        {
            try
            {
                var lista= _context.TipoDeDocumentos.ToList();
                return _mapper.Map<List<TipoDeDocumentoListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Tipos de Documentos");
            }
        }

        public void Guardar(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                if (tipoDeDocumento.TipoDeDocumentoId == 0)
                {
                    _context.TipoDeDocumentos.Add(tipoDeDocumento);
                }
                else
                {
                    var documentoInDb = _context.TipoDeDocumentos.Find(tipoDeDocumento.TipoDeDocumentoId);
                    documentoInDb.Descripcion = tipoDeDocumento.Descripcion;
                    _context.Entry(documentoInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar Agregar/Editar un Tipo De Documento");
            }
        }
    }
}
