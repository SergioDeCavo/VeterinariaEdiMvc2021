using AutoMapper;
using System.Web.Mvc;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Raza;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using System;
using System.Net;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class RazasController : Controller
    {
        private readonly IServiciosRaza _servicio;
        private readonly IServiciosTipoDeMascota _servicioTipoDeMascota;
        private readonly IMapper _mapper;

        public RazasController(IServiciosRaza servicio, IServiciosTipoDeMascota servicioTipoDeMascota)
        {
            _servicio = servicio;
            _servicioTipoDeMascota = servicioTipoDeMascota;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Razas
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<RazaListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            RazaEditViewModel razaVm = new RazaEditViewModel
            {
                TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetLista())

            };
            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(RazaEditViewModel razaEditVm)
        {
            if (!ModelState.IsValid)
            {
                razaEditVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetLista());
                return View(razaEditVm);
            }
            RazaEditDto razaDto = _mapper.Map<RazaEditDto>(razaEditVm);
            if (_servicio.Existe(razaDto))
            {
                ModelState.AddModelError(string.Empty, "Producto existente....");
                razaEditVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetLista());
                return View(razaEditVm);

            }
            try
            {
                _servicio.Guardar(razaDto);
                TempData["Msg"] = "Producto Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                razaEditVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetLista());
                return View(razaEditVm);


            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            RazaEditDto razaDto = _servicio.GetRazaPorId(id);
            if (razaDto == null)
            {
                return HttpNotFound("Còdigo de Raza NO Encontrado");
            }
            RazaEditViewModel razaVm = _mapper.Map<RazaEditViewModel>(razaDto);
            razaVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetLista());
            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RazaEditViewModel razaVm)
        {
            if (!ModelState.IsValid)
            {
                razaVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetLista());
                return View(razaVm);
            }
            RazaEditDto razaDto = _mapper.Map<RazaEditDto>(razaVm);
            if (_servicio.Existe(razaDto))
            {
                ModelState.AddModelError(string.Empty, "Producto existente....");
                razaVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetLista());
                return View(razaVm);

            }
            try
            {
                _servicio.Guardar(razaDto);
                TempData["Msg"] = "Producto Editado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                razaVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_servicioTipoDeMascota.GetLista());
                return View(razaVm);


            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazaListDto razaDto = _mapper.Map<RazaListDto>(_servicio.GetRazaPorId(id));
            if (razaDto == null)
            {
                return HttpNotFound("Còdigo de Raza inexistente...");
            }
            RazaListViewModel razaVm = _mapper.Map<RazaListViewModel>(razaDto);
            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(RazaListViewModel razaVm)
        {
            //RazaEditDto razaDto = _mapper.Map<RazaEditDto>(razaVm);
            //if (_servicio.EstaRelacionado(razaDto))
            //{
            //    ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
            //    return View(razaVm);
            //}
            try
            {
                RazaListDto razaDto = _mapper.Map<RazaListDto>(_servicio.GetRazaPorId(razaVm.RazaId));
                razaVm = _mapper.Map<RazaListViewModel>(_servicio.GetRazaPorId(razaVm.RazaId));
                _servicio.Borrar(razaVm.RazaId);
                TempData["Msg"] = "Registro Borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(razaVm);
            }
        }
    }
}
