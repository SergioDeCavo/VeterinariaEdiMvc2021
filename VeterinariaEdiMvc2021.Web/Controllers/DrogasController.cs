using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Droga;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Droga;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class DrogasController : Controller
    {
        private readonly IServiciosDroga _servicio;
        private readonly IMapper _mapper;

        public DrogasController(IServiciosDroga servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Drogas
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<DrogaListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DrogaEditViewModel drogaVm) 
        {
            if (!ModelState.IsValid)
            {
                return View(drogaVm);
            }

            DrogaEditDto drogaDto = _mapper.Map<DrogaEditDto>(drogaVm);

            if (_servicio.Existe(drogaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(drogaVm);
            }
            try
            {
                _servicio.Guardar(drogaDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(drogaVm);

            }
                      

        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrogaEditDto drogaDto = _servicio.GetDrogaPorId(id);
            if (drogaDto==null)
            {
                return HttpNotFound("Còdigo de droga inexistente...");
            }
            DrogaEditViewModel drogaVm = _mapper.Map<DrogaEditViewModel>(drogaDto);
            return View(drogaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete (DrogaEditViewModel drogaVm) 
        {
            try
            {
                drogaVm = _mapper.Map<DrogaEditViewModel>(_servicio.GetDrogaPorId(drogaVm.DrogaId));
                _servicio.Borrar(drogaVm.DrogaId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(drogaVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id) 
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrogaEditDto drogaDto = _servicio.GetDrogaPorId(id);
            DrogaEditViewModel drogaVm = _mapper.Map<DrogaEditViewModel>(drogaDto);
            return View(drogaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit(DrogaEditViewModel drogaVm) 
        {
            if (!ModelState.IsValid)
            {
                return View(drogaVm);
            }
            DrogaEditDto drogaDto = _mapper.Map<DrogaEditDto>(drogaVm);
            if (_servicio.Existe(drogaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(drogaVm);
            }
            try
            {
                _servicio.Guardar(drogaDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(drogaVm);

            }
        }
    }
}