using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.ViewModels.FormaFarmaceutica;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class FormasFarmaceuticasController : Controller
    {
        private readonly IServiciosFormaFarmaceutica _servicio;
        private readonly IMapper _mapper;

        public FormasFarmaceuticasController(IServiciosFormaFarmaceutica servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: FomaFarmaceuticas
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(listaDto)
                .OrderBy(c => c.Descripcion)
                .ToPagedList((int)page, 5);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormaFarmaceuticaEditViewModel formaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(formaVm);
            }

            FormaFarmaceuticaEditDto formaFarmaceuticaDto = _mapper.Map<FormaFarmaceuticaEditDto>(formaVm);

            if (_servicio.Existe(formaFarmaceuticaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(formaVm);
            }
            try
            {
                _servicio.Guardar(formaFarmaceuticaDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaVm);

            }
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaFarmaceuticaEditDto formaFarmaceuticaDto = _servicio.GetFormaFarmaceuticaPorId(id);
            if (formaFarmaceuticaDto == null)
            {
                return HttpNotFound("Còdigo de Forma Farmacèutica inexistente...");
            }
            FormaFarmaceuticaEditViewModel formaFarmaceuticaVm = _mapper.Map<FormaFarmaceuticaEditViewModel>(formaFarmaceuticaDto);
            return View(formaFarmaceuticaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(FormaFarmaceuticaEditViewModel formaFarmaceuticaVm)
        {
            FormaFarmaceuticaEditDto formaFarmaceuticaDto = _mapper.Map<FormaFarmaceuticaEditDto>(formaFarmaceuticaVm);
            if (_servicio.EstaRelacionado(formaFarmaceuticaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
                return View(formaFarmaceuticaVm);
            }
            try
            {
                formaFarmaceuticaVm = _mapper.Map<FormaFarmaceuticaEditViewModel>(_servicio.GetFormaFarmaceuticaPorId(formaFarmaceuticaVm.FormaFarmaceuticaId));
                _servicio.Borrar(formaFarmaceuticaVm.FormaFarmaceuticaId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaFarmaceuticaVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaFarmaceuticaEditDto formaDto = _servicio.GetFormaFarmaceuticaPorId(id);
            FormaFarmaceuticaEditViewModel formaVm = _mapper.Map<FormaFarmaceuticaEditViewModel>(formaDto);
            return View(formaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(FormaFarmaceuticaEditViewModel formaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(formaVm);
            }
            FormaFarmaceuticaEditDto formaDto = _mapper.Map<FormaFarmaceuticaEditDto>(formaVm);
            if (_servicio.Existe(formaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(formaVm);
            }
            try
            {
                _servicio.Guardar(formaDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaVm);

            }
        }
    }
}