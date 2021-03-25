using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Laboratorio;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class LaboratoriosController : Controller
    {
        private readonly IServiciosLaboratorio _servicio;
        private readonly IMapper _mapper;

        public LaboratoriosController(IServiciosLaboratorio servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Laboratorios
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<LaboratorioListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LaboratorioEditViewModel laboratorioVm)
        {
            if (!ModelState.IsValid)
            {
                return View(laboratorioVm);
            }

            LaboratorioEditDto laboratorioDto = _mapper.Map<LaboratorioEditDto>(laboratorioVm);

            if (_servicio.Existe(laboratorioDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(laboratorioVm);
            }
            try
            {
                _servicio.Guardar(laboratorioDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(laboratorioVm);

            }
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaboratorioEditDto laboratorioDto = _servicio.GetLaboratorioPorId(id);
            if (laboratorioDto == null)
            {
                return HttpNotFound("Còdigo de Laboratorio inexistente...");
            }
            LaboratorioEditViewModel laboratorioVm = _mapper.Map<LaboratorioEditViewModel>(laboratorioDto);
            return View(laboratorioVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(LaboratorioEditViewModel laboratorioVm)
        {
            try
            {
                laboratorioVm = _mapper.Map<LaboratorioEditViewModel>(_servicio.GetLaboratorioPorId(laboratorioVm.LaboratorioId));
                _servicio.Borrar(laboratorioVm.LaboratorioId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(laboratorioVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaboratorioEditDto laboratorioDto = _servicio.GetLaboratorioPorId(id);
            LaboratorioEditViewModel laboratorioVm = _mapper.Map<LaboratorioEditViewModel>(laboratorioDto);
            return View(laboratorioVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(LaboratorioEditViewModel laboratorioVm)
        {
            if (!ModelState.IsValid)
            {
                return View(laboratorioVm);
            }
            LaboratorioEditDto laboratorioDto = _mapper.Map<LaboratorioEditDto>(laboratorioVm);
            if (_servicio.Existe(laboratorioDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(laboratorioVm);
            }
            try
            {
                _servicio.Guardar(laboratorioDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(laboratorioVm);

            }
        }
    }
}