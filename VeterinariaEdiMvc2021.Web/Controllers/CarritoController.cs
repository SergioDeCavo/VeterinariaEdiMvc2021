using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Carrito;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IServiciosMedicamento _servicioMedicamento;
        private IMapper _mapper;

        public CarritoController(IServiciosMedicamento servicioMedicamento)
        {
            _servicioMedicamento = servicioMedicamento;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public PartialViewResult Summary(Carrito carrito)
        {
            return PartialView(carrito);
        }

        public ViewResult Index(Carrito carrito, string returnUrl)
        {
            List<ItemCarritoListViewModel> listaItems = _mapper.Map<List<ItemCarritoListViewModel>>(carrito.GetItems());
            return View(new CarritoListViewModel
            {
                Items = listaItems,
                ReturnUrl=returnUrl
            });
        }

        public RedirectToRouteResult AgregarAlCarrito(Carrito carrito, int MedicamentoId, string returnUrl)
        {
            MedicamentoEditDto medicamentoDto = _servicioMedicamento.GetMedicamentoPorId(MedicamentoId);
            if (medicamentoDto != null)
            {
                Medicamento medicamento = _mapper.Map<Medicamento>(medicamentoDto);
                carrito.AgregarAlCarrito(medicamento, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult EliminarDelCarrito(Carrito carrito, int medicamentoId, string returnUrl)
        {
            Medicamento medicamento = _mapper.Map<Medicamento>(_servicioMedicamento.GetMedicamentoPorId(medicamentoId));
            if (medicamento != null)
            {
                carrito.EliminarDelCarrito(medicamento);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}