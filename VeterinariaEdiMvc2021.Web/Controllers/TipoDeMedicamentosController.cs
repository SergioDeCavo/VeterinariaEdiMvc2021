using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMedicamento;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class TipoDeMedicamentosController : Controller
    {
        private readonly IServiciosTipoDeMedicamento _servicio;
        private readonly IMapper _mapper;

        public TipoDeMedicamentosController(IServiciosTipoDeMedicamento servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: TipoDeMedicamentos
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(listaDto)
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
        public ActionResult Create(TipoDeMedicamentoEditViewModel tipoMedVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoMedVm);
            }

            TipoDeMedicamentoEditDto tipoMedDto = _mapper.Map<TipoDeMedicamentoEditDto>(tipoMedVm);

            if (_servicio.Existe(tipoMedDto))
            {
                ModelState.AddModelError(string.Empty, "Registro Existente...");
                return View(tipoMedVm);
            }
            try
            {
                _servicio.Guardar(tipoMedDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoMedVm);

            }
        }

        [HttpGet]
        

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeMedicamentoEditDto tipoMedDto = _servicio.GetipoDeMedicamentoPorId(id);
            if (tipoMedDto == null)
            {
                return HttpNotFound("Còdigo de Tipo de Medicamento inexistente...");
            }
            TipoDeMedicamentoEditViewModel tipoMedVm = _mapper.Map<TipoDeMedicamentoEditViewModel>(tipoMedDto);
            return View(tipoMedVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(TipoDeMedicamentoEditViewModel tipoMedVm)
        {
            TipoDeMedicamentoEditDto tipoMedDto = _mapper.Map<TipoDeMedicamentoEditDto>(tipoMedVm);
            if (_servicio.EstaRelacionado(tipoMedDto))
            {
                ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
                return View(tipoMedVm);
            }
            try
            {
                tipoMedVm = _mapper.Map<TipoDeMedicamentoEditViewModel>(_servicio.GetipoDeMedicamentoPorId(tipoMedVm.TipoDeMedicamentoId));
                _servicio.Borrar(tipoMedVm.TipoDeMedicamentoId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoMedVm);
            }
        }

        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeMedicamentoEditDto tipoMedDto = _servicio.GetipoDeMedicamentoPorId(id);
            TipoDeMedicamentoEditViewModel tipoMedVm = _mapper.Map<TipoDeMedicamentoEditViewModel>(tipoMedDto);
            return View(tipoMedVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TipoDeMedicamentoEditViewModel tipoMedVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoMedVm);
            }
            TipoDeMedicamentoEditDto tipoMedDto = _mapper.Map<TipoDeMedicamentoEditDto>(tipoMedVm);
            if (_servicio.Existe(tipoMedDto))
            {
                ModelState.AddModelError(string.Empty, "Registro duplicado....");
                return View(tipoMedVm);
            }
            try
            {
                _servicio.Guardar(tipoMedDto);
                TempData["Msg"] = "Registro Modeificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoMedVm);

            }
        }
    }
}