using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Proveedor;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly IServiciosProveedor _servicio;
        private readonly IServiciosLocalidad _serviciosLocalidad;
        private readonly IServiciosProvincia _serviciosProvincia;
        private readonly IMapper _mapper;

        public ProveedoresController(IServiciosProveedor servicio, IServiciosLocalidad serviciosLocalidad, IServiciosProvincia serviciosProvincia)
        {
            _servicio = servicio;
            _serviciosLocalidad = serviciosLocalidad;
            _serviciosProvincia = serviciosProvincia;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        // GET: Empleados
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<ProveedorListViewModel>>(listaDto)
                .OrderBy(c => c.RazonSocial)
                .ThenBy(c => c.Localidad)
                .ToPagedList((int)page, 5);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            ProveedorEditViewModel proveedorVm = new ProveedorEditViewModel
            {
                Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null)),
                Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista())
            };
            return View(proveedorVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProveedorEditViewModel proveedorEditVm)
        {
            if (!ModelState.IsValid)
            {
                proveedorEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                proveedorEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(proveedorEditVm);
            }
            ProveedorEditDto proveedorDto = _mapper.Map<ProveedorEditDto>(proveedorEditVm);
            if (_servicio.Existe(proveedorDto))
            {
                ModelState.AddModelError(string.Empty, "Proveedor Existente");
                proveedorEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                proveedorEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(proveedorEditVm);

            }
            try
            {
                _servicio.Guardar(proveedorDto);
                TempData["Msg"] = "Proveedor Agregado....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                proveedorEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                proveedorEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(proveedorEditVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorEditDto proveedorDto = _servicio.GetProveedorPorId(id);
            if (proveedorDto == null)
            {
                return HttpNotFound("Còdigo de Proveedor No Encontrado");
            }
            ProveedorEditViewModel proveedorVm = _mapper.Map<ProveedorEditViewModel>(proveedorDto);
            proveedorVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
            proveedorVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
            return View(proveedorVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProveedorEditViewModel proveedorVm)
        {
            if (!ModelState.IsValid)
            {
                proveedorVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                proveedorVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(proveedorVm);
            }
            ProveedorEditDto proveedorDto = _mapper.Map<ProveedorEditDto>(proveedorVm);
            if (_servicio.Existe(proveedorDto))
            {
                ModelState.AddModelError(string.Empty, "Proveedor Existente");
                proveedorVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                proveedorVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(proveedorVm);

            }
            try
            {
                _servicio.Guardar(proveedorDto);
                TempData["Msg"] = "Proveedor Editado....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                proveedorVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                proveedorVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(proveedorVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var proveedorDto = _servicio.GetProveedorPorId(id);
            if (proveedorDto == null)
            {
                return HttpNotFound("Còdigo de Proveedor inexistente");
            }
            ProveedorListViewModel proveedorVm = _mapper.Map<ProveedorListViewModel>(proveedorDto);
            proveedorVm.Localidad = (_serviciosLocalidad.GetLocalidadPorId(proveedorDto.LocalidadId)).NombreLocalidad;
            return View(proveedorVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProveedorListViewModel proveedorVm)
        {
            try
            {
                ProveedorListDto proveedorDto = _mapper.Map<ProveedorListDto>(_servicio.GetProveedorPorId(proveedorVm.ProveedorId));
                proveedorVm = _mapper.Map<ProveedorListViewModel>(proveedorDto);
                _servicio.Borrar(proveedorVm.ProveedorId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(proveedorVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorEditDto proveedorDto = _servicio.GetProveedorPorId(id);
            if (proveedorDto == null)
            {
                return HttpNotFound("Còdigo de Proveedor No Encontrado");
            }
            ProveedorEditViewModel proveedorVm = _mapper.Map<ProveedorEditViewModel>(proveedorDto);
            proveedorVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
            proveedorVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
            return View(proveedorVm);
        }
    }
}