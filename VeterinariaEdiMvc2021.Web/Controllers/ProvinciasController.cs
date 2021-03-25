using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly IServiciosProvincia _servicio;
        private readonly IMapper _mapper;

        public ProvinciasController(IServiciosProvincia servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Provincias
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<ProvinciaListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProvinciaEditViewModel provinciaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(provinciaVm);
            }

            ProvinciaEditDto provinciaDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);

            if (_servicio.Existe(provinciaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(provinciaVm);
            }
            try
            {
                _servicio.Guardar(provinciaDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(provinciaVm);

            }
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvinciaEditDto provinciaDto = _servicio.GetProvinciaPorId(id);
            if (provinciaDto == null)
            {
                return HttpNotFound("Còdigo de Provincia inexistente...");
            }
            ProvinciaEditViewModel provinciaVm = _mapper.Map<ProvinciaEditViewModel>(provinciaDto);
            return View(provinciaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(ProvinciaEditViewModel provinciaVm)
        {
            ProvinciaEditDto provinciaDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);
            if (_servicio.EstaRelacionado(provinciaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
                return View(provinciaVm);
            }
            try
            {
                provinciaVm = _mapper.Map<ProvinciaEditViewModel>(_servicio.GetProvinciaPorId(provinciaVm.ProvinciaId));
                _servicio.Borrar(provinciaVm.ProvinciaId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(provinciaVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvinciaEditDto provinciaDto = _servicio.GetProvinciaPorId(id);
            ProvinciaEditViewModel provinciaVm = _mapper.Map<ProvinciaEditViewModel>(provinciaDto);
            return View(provinciaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(ProvinciaEditViewModel provinciaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(provinciaVm);
            }
            ProvinciaEditDto provinciaDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);
            if (_servicio.Existe(provinciaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(provinciaVm);
            }
            try
            {
                _servicio.Guardar(provinciaDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(provinciaVm);

            }
        }
    }
}