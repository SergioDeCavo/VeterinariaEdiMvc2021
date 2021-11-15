using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Mapeador;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosVenta : IServiciosVenta
    {
        private readonly IRepositorioVentas _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosVenta(IRepositorioVentas repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;

        }

        public List<Venta> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
