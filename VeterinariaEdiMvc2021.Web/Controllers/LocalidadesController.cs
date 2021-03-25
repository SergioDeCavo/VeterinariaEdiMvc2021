using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Raza;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly IServiciosLocalidad _servicio;
        private readonly IServiciosProvincia _servicioProvincias;
        private readonly IMapper _mapper;

        public LocalidadesController(IServiciosLocalidad servicio, IServiciosProvincia servicioProvincias)
        {
            _servicio = servicio;
            _servicioProvincias = servicioProvincias;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Localidades
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<LocalidadListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create() 
        {
            LocalidadEditViewModel localidadVm = new LocalidadEditViewModel
            {
                Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincias.GetLista())

            };
            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(LocalidadEditViewModel localidadEditVm) 
        {
            if (!ModelState.IsValid)
            {
                localidadEditVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincias.GetLista());
                return View(localidadEditVm);
            }
            LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadEditVm);
            if (_servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, "Producto existente....");
                localidadEditVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincias.GetLista());
                return View(localidadEditVm);

            }
            try
            {
                _servicio.Guardar(localidadDto);
                TempData["Msg"] = "Producto Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                localidadEditVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincias.GetLista());
                return View(localidadEditVm);


            }

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            LocalidadEditDto localidadDto = _servicio.GetLocalidadPorId(id);
            if (localidadDto==null)
            {
                return HttpNotFound("Còdigo de Localidad NO Encontrado");
            }
            LocalidadEditViewModel localidadVm = _mapper.Map<LocalidadEditViewModel>(localidadDto);
            localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincias.GetLista());

            return View(localidadVm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocalidadEditViewModel localidadVm) 
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincias.GetLista());
                return View(localidadVm);
            }
            LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadVm);
            if (_servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, "Producto existente....");
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincias.GetLista());
                return View(localidadVm);

            }
            try
            {
                _servicio.Guardar(localidadDto);
                TempData["Msg"] = "Producto Editado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincias.GetLista());
                return View(localidadVm);


            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalidadListDto localidadDto = _mapper.Map<LocalidadListDto>(_servicio.GetLocalidadPorId(id));
            if (localidadDto == null)
            {
                return HttpNotFound("Còdigo de Localidad inexistente...");
            }
            LocalidadListViewModel localidadVm = _mapper.Map<LocalidadListViewModel>(localidadDto);
            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(LocalidadListViewModel localidadVm)
        {
            //LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadVm);
            //if (_servicio.EstaRelacionado(localidadDto))
            //{
            //    ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
            //    return View(localidadVm);
            //}
            try
            {
                LocalidadListDto localidadDto = _mapper.Map<LocalidadListDto>(_servicio.GetLocalidadPorId(localidadVm.LocalidadId));
                localidadVm = _mapper.Map<LocalidadListViewModel>(_servicio.GetLocalidadPorId(localidadVm.LocalidadId));
                _servicio.Borrar(localidadVm.LocalidadId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(localidadVm);
            }
        }
    }
}