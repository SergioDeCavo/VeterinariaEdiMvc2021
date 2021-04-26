using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeServicio;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeServicio;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class TipoDeServiciosController : Controller
    {
        private readonly IServiciosTipoDeServicio _servicio;
        private readonly IMapper _mapper;

        public TipoDeServiciosController(IServiciosTipoDeServicio servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: TipoDeServicios
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoDeServicioListViewModel>>(listaDto)
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
        public ActionResult Create(TipoDeServicioEditViewModel tipoSerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoSerVm);
            }

            TipoDeServicioEditDto tipoSerDto = _mapper.Map<TipoDeServicioEditDto>(tipoSerVm);

            if (_servicio.Existe(tipoSerDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(tipoSerVm);
            }
            try
            {
                _servicio.Guardar(tipoSerDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoSerVm);

            }
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeServicioEditDto tipoSerDto = _servicio.GetipoDeServicioPorId(id);
            if (tipoSerDto == null)
            {
                return HttpNotFound("Còdigo de Tipo de Servicio inexistente...");
            }
            TipoDeServicioEditViewModel tipoSerVm = _mapper.Map<TipoDeServicioEditViewModel>(tipoSerDto);
            return View(tipoSerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(TipoDeServicioEditViewModel tipoSerVm)
        {
            TipoDeServicioEditDto tipoSerDto = _mapper.Map<TipoDeServicioEditDto>(tipoSerVm);
            //if (_servicio.EstaRelacionado(tipoSerDto))
            //{
            //    ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
            //    return View(tipoSerVm);
            //}
            try
            {
                tipoSerVm = _mapper.Map<TipoDeServicioEditViewModel>(_servicio.GetipoDeServicioPorId(tipoSerVm.TipoDeServicioId));
                _servicio.Borrar(tipoSerVm.TipoDeServicioId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoSerVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeServicioEditDto tipoSerDto = _servicio.GetipoDeServicioPorId(id);
            TipoDeServicioEditViewModel tipoSerVm = _mapper.Map<TipoDeServicioEditViewModel>(tipoSerDto);
            return View(tipoSerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TipoDeServicioEditViewModel tipoSerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoSerVm);
            }
            TipoDeServicioEditDto tipoSerDto = _mapper.Map<TipoDeServicioEditDto>(tipoSerVm);
            if (_servicio.Existe(tipoSerDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(tipoSerVm);
            }
            try
            {
                _servicio.Guardar(tipoSerDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoSerVm);

            }
        }
    }
}