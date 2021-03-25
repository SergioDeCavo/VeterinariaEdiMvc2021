using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosTipoDeDocumento : IServiciosTipoDeDocumento
    {
        private readonly IRepositorioTipoDeDocumentos _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosTipoDeDocumento(IRepositorioTipoDeDocumentos repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeDocumentoEditDto tipoDeDocumentoDto)
        {
            try
            {
                TipoDeDocumento tipoDeDocumento = _mapper.Map<TipoDeDocumento>(tipoDeDocumentoDto);
                return _repositorio.Existe(tipoDeDocumento);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public TipoDeDocumentoEditDto GetipoDeDocumentoPorId(int? id)
        {
            try
            {
                return _repositorio.GetipoDeDocumentoPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDeDocumentoListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
                //return _mapper.Map<List<TipoDeDocumentoListDto>>(lista);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeDocumentoEditDto tipoDeDocumentoDto)
        {
            try
            {
                TipoDeDocumento tipoDeDocumento = _mapper.Map<TipoDeDocumento>(tipoDeDocumentoDto);
                _repositorio.Guardar(tipoDeDocumento);
                _unitOfWork.Save();
                tipoDeDocumentoDto.TipoDeDocumentoId = tipoDeDocumento.TipoDeDocumentoId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
