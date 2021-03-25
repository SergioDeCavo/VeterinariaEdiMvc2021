using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeTarea;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeTarea;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class TipoDeTareasController : Controller
    {
        private readonly IServiciosTipoDeTarea _servicio;
        private readonly IMapper _mapper;

        public TipoDeTareasController(IServiciosTipoDeTarea servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: TipoDeTareas
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoDeTareaListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeTareaEditViewModel tipoTarVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoTarVm);
            }

            TipoDeTareaEditDto tipoTarDto = _mapper.Map<TipoDeTareaEditDto>(tipoTarVm);

            if (_servicio.Existe(tipoTarDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(tipoTarVm);
            }
            try
            {
                _servicio.Guardar(tipoTarDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoTarVm);

            }
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeTareaEditDto tipoTarDto = _servicio.GetipoDeTareaPorId(id);
            if (tipoTarDto == null)
            {
                return HttpNotFound("Còdigo de Tipo de Tarea inexistente...");
            }
            TipoDeTareaEditViewModel tipoTarVm = _mapper.Map<TipoDeTareaEditViewModel>(tipoTarDto);
            return View(tipoTarVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(TipoDeTareaEditViewModel tipoTarVm)
        {
            try
            {
                tipoTarVm = _mapper.Map<TipoDeTareaEditViewModel>(_servicio.GetipoDeTareaPorId(tipoTarVm.TipoDeTareaId));
                _servicio.Borrar(tipoTarVm.TipoDeTareaId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoTarVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeTareaEditDto tipoTarDto = _servicio.GetipoDeTareaPorId(id);
            TipoDeTareaEditViewModel tipoTarVm = _mapper.Map<TipoDeTareaEditViewModel>(tipoTarDto);
            return View(tipoTarVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TipoDeTareaEditViewModel tipoTarVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoTarVm);
            }
            TipoDeTareaEditDto tipoTarDto = _mapper.Map<TipoDeTareaEditDto>(tipoTarVm);
            if (_servicio.Existe(tipoTarDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(tipoTarVm);
            }
            try
            {
                _servicio.Guardar(tipoTarDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoTarVm);

            }
        }
    }
}