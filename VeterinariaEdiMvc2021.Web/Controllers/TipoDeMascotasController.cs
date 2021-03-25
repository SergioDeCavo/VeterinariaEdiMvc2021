using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeTarea;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class TipoDeMascotasController : Controller
    {
        private readonly IServiciosTipoDeMascota _servicio;
        private readonly IMapper _mapper;

        public TipoDeMascotasController(IServiciosTipoDeMascota servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: TipoDeMascotas
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoDeMascotaListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeMascotaEditViewModel tipoMasVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoMasVm);
            }

            TipoDeMascotaEditDto tipoMasDto = _mapper.Map<TipoDeMascotaEditDto>(tipoMasVm);

            if (_servicio.Existe(tipoMasDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(tipoMasVm);
            }
            try
            {
                _servicio.Guardar(tipoMasDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoMasVm);

            }
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeMascotaEditDto tipoMasDto = _servicio.GetipoDeMascotaPorId(id);
            if (tipoMasDto == null)
            {
                return HttpNotFound("Còdigo de Tipo de Mascota inexistente...");
            }
            TipoDeMascotaEditViewModel tipoMasVm = _mapper.Map<TipoDeMascotaEditViewModel>(tipoMasDto);
            return View(tipoMasVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(TipoDeMascotaEditViewModel tipoMasVm)
        {
            TipoDeMascotaEditDto tipoMasDto = _mapper.Map<TipoDeMascotaEditDto>(tipoMasVm);
            if (_servicio.EstaRelacionado(tipoMasDto))
            {
                ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
                return View(tipoMasVm);
            }
            try
            {
                tipoMasVm = _mapper.Map<TipoDeMascotaEditViewModel>(_servicio.GetipoDeMascotaPorId(tipoMasVm.TipoDeMascotaId));
                _servicio.Borrar(tipoMasVm.TipoDeMascotaId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoMasVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeMascotaEditDto tipoMasDto = _servicio.GetipoDeMascotaPorId(id);
            TipoDeMascotaEditViewModel tipoMasVm = _mapper.Map<TipoDeMascotaEditViewModel>(tipoMasDto);
            return View(tipoMasVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TipoDeMascotaEditViewModel tipoMasVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoMasVm);
            }
            TipoDeMascotaEditDto tipoMasDto = _mapper.Map<TipoDeMascotaEditDto>(tipoMasVm);
            if (_servicio.Existe(tipoMasDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(tipoMasVm);
            }
            try
            {
                _servicio.Guardar(tipoMasDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoMasVm);

            }
        }
    }
}