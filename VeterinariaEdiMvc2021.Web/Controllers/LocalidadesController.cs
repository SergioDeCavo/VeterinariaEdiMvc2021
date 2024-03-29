﻿using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Entidades.DTOs.Localidad;
using VeterinariaEdiMvc2021.Entidades.DTOs.Provincia;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.Entidades;
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
        private VeterinariaEdiMvc2021DbContext db = new VeterinariaEdiMvc2021DbContext();

        public LocalidadesController(IServiciosLocalidad servicio, IServiciosProvincia servicioProvincias)
        {
            _servicio = servicio;
            _servicioProvincias = servicioProvincias;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Localidades


        public ActionResult Index(int? provinciaSeleccionadaId=null, int? page=null)
        {
            page = (page ?? 1);

            List<Localidad> lista;

            if (provinciaSeleccionadaId != null)
            {
                lista = _servicio.GetLista(provinciaSeleccionadaId.Value);

            }
            else
            {
                lista = _servicio.GetLista();
            }

            if (provinciaSeleccionadaId != null)
            {
                Session["provinciaSeleccionadaId"] = provinciaSeleccionadaId;
            }
            else
            {
                if (Session["provinciaSeleccionadaId"] != null)
                {
                    provinciaSeleccionadaId = (int)Session["provinciaSeleccionadaId"];
                }
            }

            if (provinciaSeleccionadaId != null)
            {
                if (provinciaSeleccionadaId.Value > 0)
                {
                    lista = _servicio.GetLista(provinciaSeleccionadaId.Value);
                }
                else
                {
                    lista = _servicio.GetLista();
                }
            }
            else
            {
                lista = _servicio.GetLista();
            }

            //var localidades = provinciaSeleccionadaId.HasValue ? db.Localidades.Where(l => l.ProvinciaId == provinciaSeleccionadaId) : db.Localidades;
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<LocalidadListViewModel>>(listaDto)

            .OrderBy(c => c.NombreLocalidad)
            .ThenBy(c => c.Provincia)
            .ToPagedList((int)page, 5);
            var listaVma = Mapeador.Mapeador.ConstruirListaLocalidadListVm(lista);
            var listaProvincias = _servicioProvincias.GetLista();
            listaProvincias.Insert(0, new ProvinciaListDto() { ProvinciaId = 0, NombreProvincia = "[Seleccione una Provincia]" });
            listaProvincias.Insert(1, new ProvinciaListDto() { ProvinciaId = -1, NombreProvincia = "[Ver Todas]" });
            ViewBag.ListaProvincias = new SelectList(listaProvincias, "ProvinciaId", "NombreProvincia", provinciaSeleccionadaId);
            return View(listaVma.ToPagedList((int)page,5));
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
            //LocalidadListDto localidadDto = _mapper.Map<LocalidadListDto>(_servicio.GetLocalidadPorId(id));
            var localidadDto = _servicio.GetLocalidadPorId(id);
            if (localidadDto == null)
            {
                return HttpNotFound("Còdigo de Localidad inexistente...");
            }
            LocalidadListViewModel localidadVm = _mapper.Map<LocalidadListViewModel>(localidadDto);
            localidadVm.Provincia = (_servicioProvincias.GetProvinciaPorId(localidadDto.ProvinciaId)).NombreProvincia;
            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(LocalidadListViewModel localidadVm)
        {
            LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadVm);
            if (_servicio.EstaRelacionado(localidadDto))
            {
                ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
                return View(localidadVm);
            }
            try
            {
                LocalidadListDto locDto = _mapper.Map<LocalidadListDto>(_servicio.GetLocalidadPorId(localidadVm.LocalidadId));
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