using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Empleado;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Empleado;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeTarea;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IServiciosEmpleado _servicio;
        private readonly IServiciosTipoDeDocumento _serviciosTipoDeDocumento;
        private readonly IServiciosLocalidad _serviciosLocalidad;
        private readonly IServiciosProvincia _serviciosProvincia;
        private readonly IServiciosTipoDeTarea _serviciosTipoDeTarea;
        private readonly IMapper _mapper;

        public EmpleadosController(IServiciosEmpleado servicio, IServiciosTipoDeDocumento serviciosTipoDeDocumento, IServiciosLocalidad serviciosLocalidad, IServiciosProvincia serviciosProvincia, IServiciosTipoDeTarea serviciosTipoDeTarea)
        {
            _servicio = servicio;
            _serviciosTipoDeDocumento = serviciosTipoDeDocumento;
            _serviciosLocalidad = serviciosLocalidad;
            _serviciosProvincia = serviciosProvincia;
            _serviciosTipoDeTarea = serviciosTipoDeTarea;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Empleados
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<EmpleadoListViewModel>>(listaDto)
                .OrderBy(c => c.Empleado)
                .ThenBy(c => c.TipoDeTarea)
                .ToPagedList((int)page, 5);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            EmpleadoEditViewModel empleadoVm = new EmpleadoEditViewModel
            {
                TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista()),
                Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null)),
                Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista()),
                TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista())
            };
            return View(empleadoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoEditViewModel empleadoEditVm)
        {
            if (!ModelState.IsValid)
            {
                empleadoEditVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                empleadoEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                empleadoEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                empleadoEditVm.TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista());
                return View(empleadoEditVm);
            }
           EmpleadoEditDto empleadoDto = _mapper.Map<EmpleadoEditDto>(empleadoEditVm);
            if (_servicio.Existe(empleadoDto))
            {
                ModelState.AddModelError(string.Empty, "Empleado Existente");
                empleadoEditVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                empleadoEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                empleadoEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                empleadoEditVm.TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista());
                return View(empleadoEditVm);

            }
            try
            {
                _servicio.Guardar(empleadoDto);
                TempData["Msg"] = "Empleado Agregado....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                empleadoEditVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                empleadoEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                empleadoEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                empleadoEditVm.TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista());
                return View(empleadoEditVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoEditDto empleadoDto = _servicio.GetEmpleadoPorId(id);
            if (empleadoDto == null)
            {
                return HttpNotFound("Còdigo de Empleado No Encontrado");
            }
            EmpleadoEditViewModel empleadoVm = _mapper.Map<EmpleadoEditViewModel>(empleadoDto);
            empleadoVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
            empleadoVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
            empleadoVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
            empleadoVm.TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista());
            return View(empleadoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadoEditViewModel empleadoVm) 
        {
            if (!ModelState.IsValid)
            {
                empleadoVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                empleadoVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                empleadoVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                empleadoVm.TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista());
                return View(empleadoVm);
            }
            EmpleadoEditDto empleadoDto = _mapper.Map<EmpleadoEditDto>(empleadoVm);
            if (_servicio.Existe(empleadoDto))
            {
                ModelState.AddModelError(string.Empty, "Empleado Existente");
                empleadoVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                empleadoVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                empleadoVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                empleadoVm.TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista());
                return View(empleadoVm);

            }
            try
            {
                _servicio.Guardar(empleadoDto);
                TempData["Msg"] = "Empleado Editado....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                empleadoVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                empleadoVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                empleadoVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                empleadoVm.TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista());
                return View(empleadoVm);

            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleadoDto = _servicio.GetEmpleadoPorId(id);
            if (empleadoDto == null)
            {
                return HttpNotFound("Còdigo de Empleado inexistente");
            }
            EmpleadoListViewModel empleadoVm = _mapper.Map<EmpleadoListViewModel>(empleadoDto);
            empleadoVm.TipoDeTarea = (_serviciosTipoDeTarea.GetipoDeTareaPorId(empleadoDto.TipoDeTareaId)).Descripcion;
            empleadoVm.Localidad = (_serviciosLocalidad.GetLocalidadPorId(empleadoDto.LocalidadId)).NombreLocalidad;
            return View(empleadoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmpleadoListViewModel empleadoVm)
        {
            try
            {
                EmpleadoListDto empleadoDto = _mapper.Map<EmpleadoListDto>(_servicio.GetEmpleadoPorId(empleadoVm.EmpleadoId));
                empleadoVm = _mapper.Map<EmpleadoListViewModel>(empleadoDto);
                _servicio.Borrar(empleadoVm.EmpleadoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(empleadoVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoEditDto empleadoDto = _servicio.GetEmpleadoPorId(id);
            if (empleadoDto == null)
            {
                return HttpNotFound("Còdigo de Empleado No Encontrado");
            }
            EmpleadoEditViewModel empleadoVm = _mapper.Map<EmpleadoEditViewModel>(empleadoDto);
            empleadoVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
            empleadoVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
            empleadoVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
            empleadoVm.TipoDeTarea = _mapper.Map<List<TipoDeTareaListViewModel>>(_serviciosTipoDeTarea.GetLista());
            return View(empleadoVm);
        }
    }
}