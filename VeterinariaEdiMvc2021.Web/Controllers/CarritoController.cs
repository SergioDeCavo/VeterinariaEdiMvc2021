using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Carrito;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class CarritoController : Controller
    {
        
        private readonly IServiciosMedicamento _servicio;
        public CarritoController(IServiciosMedicamento servicio)
        {
            _servicio = servicio;
        }
        // GET: Carrito
        public CarritoController()
        {
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarritoViewModel
            {
                Carrito = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        //public RedirectToRouteResult AddToCart(int medicamentoId, string returnUrl)
        //{
        //    MedicamentoListViewModel medicamentoVm = Mapeador.Mapeador.ConstruirMedicamentoListVm(Mapeador.Mapeador.CrearMapper.Map_servicios.GetMedicamentoPorId(medicamentoId));

        //    if (medicamentoVm != null)
        //    {
        //        GetCart().AddItem(medicamentoVm, 1);
        //    }
        //    return RedirectToAction("Index", new { returnUrl });
        //}

        public RedirectToRouteResult RemoveFromCart(int medicamentoId, string returnUrl)
        {
            GetCart().RemoveItem(medicamentoId);
            return RedirectToAction("Index", new { returnUrl });
        }

        private CarritoModel GetCart()
        {
            CarritoModel carrito = (CarritoModel)Session["Carrito"];
            if (carrito == null)
            {
                carrito = new CarritoModel();
                Session["Carrito"] = carrito;
            }
            return carrito;
        }

    }

}
