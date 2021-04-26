using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeTarea;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class TipoDeDocumentosController : Controller
    {
        private readonly IServiciosTipoDeDocumento _servicio;
        private readonly IMapper _mapper;

        public TipoDeDocumentosController(IServiciosTipoDeDocumento servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: TipoDeDocumentos
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoDeDocumentoListViewModel>>(listaDto)
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
        public ActionResult Create(TipoDeDocumentoEditViewModel tipoDocVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoDocVm);
            }

            TipoDeDocumentoEditDto tipoDocDto = _mapper.Map<TipoDeDocumentoEditDto>(tipoDocVm);

            if (_servicio.Existe(tipoDocDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(tipoDocVm);
            }
            try
            {
                _servicio.Guardar(tipoDocDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoDocVm);

            }
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeDocumentoEditDto tipoDocDto = _servicio.GetipoDeDocumentoPorId(id);
            if (tipoDocDto == null)
            {
                return HttpNotFound("Còdigo de Tipo de Documento inexistente...");
            }
            TipoDeDocumentoEditViewModel tipoDocVm = _mapper.Map<TipoDeDocumentoEditViewModel>(tipoDocDto);
            return View(tipoDocVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(TipoDeDocumentoEditViewModel tipoDocVm)
        {
            TipoDeDocumentoEditDto tipoDocDto = _mapper.Map<TipoDeDocumentoEditDto>(tipoDocVm);
            if (_servicio.EstaRelacionado(tipoDocDto))
            {
                ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
                return View(tipoDocVm);
            }
            try
            {
                tipoDocVm = _mapper.Map<TipoDeDocumentoEditViewModel>(_servicio.GetipoDeDocumentoPorId(tipoDocVm.TipoDeDocumentoId));
                _servicio.Borrar(tipoDocVm.TipoDeDocumentoId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoDocVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeDocumentoEditDto tipoDocDto = _servicio.GetipoDeDocumentoPorId(id);
            TipoDeDocumentoEditViewModel tipoDocVm = _mapper.Map<TipoDeDocumentoEditViewModel>(tipoDocDto);
            return View(tipoDocVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TipoDeDocumentoEditViewModel tipoDocVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoDocVm);
            }
            TipoDeDocumentoEditDto tipoDocDto = _mapper.Map<TipoDeDocumentoEditDto>(tipoDocVm);
            if (_servicio.Existe(tipoDocDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(tipoDocVm);
            }
            try
            {
                _servicio.Guardar(tipoDocDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoDocVm);

            }
        }
    }
}