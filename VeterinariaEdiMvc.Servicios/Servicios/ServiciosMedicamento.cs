using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosMedicamento : IServiciosMedicamento
    {
        private readonly IRepositorioMedicamentos _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosMedicamento(IRepositorioMedicamentos repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int medicamentoId)
        {
            try
            {
                _repositorio.Borrar(medicamentoId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(MedicamentoEditDto medicamentoEditDto)
        {
            try
            {
                Medicamento medicamento = _mapper.Map<Medicamento>(medicamentoEditDto);
                return _repositorio.Existe(medicamento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public List<MedicamentoListDto> GetLista(string tipoDeMedicamento)
        {
            try
            {
                return _repositorio.GetLista(tipoDeMedicamento);
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los Medicamentos");
            }
        }

        public MedicamentoEditDto GetMedicamentoPorId(int? id)
        {
            try
            {
                return _repositorio.GetMedicamentoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Guardar(MedicamentoEditDto medicamentoDto)
        {
            try
            {
                Medicamento medicamento = _mapper.Map<Medicamento>(medicamentoDto);
                _repositorio.Guardar(medicamento);
                _unitOfWork.Save();
                medicamentoDto.MedicamentoId = medicamento.MedicamentoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
