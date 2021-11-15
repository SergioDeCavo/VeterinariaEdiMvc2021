using AutoMapper;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Venta;


namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class VentasController : Controller
    {
        private readonly IServiciosVenta _servicio;
        private readonly IServiciosCliente _servicioCliente;
        private readonly IMapper _mapper;

        public VentasController(IServiciosVenta servicio, IServiciosCliente servicioCliente)
        {
            _servicio = servicio;
            _servicioCliente = servicioCliente;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Ventas
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<VentaListViewModel>>(listaDto)
                .OrderBy(c => c.FechaVenta)
                .ToPagedList((int)page, 5);
            return View(listaVm);

            return View(listaVm);
        }
    }
}