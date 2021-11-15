using AutoMapper;
using System.Web.Mvc;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Raza;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using System;
using System.Net;
using System.Linq;
using PagedList;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class RazasController : Controller
    {
        private readonly IServiciosRaza _servicio;
        private readonly IServiciosTipoDeMascota _serviciosTipoDeMascota;
        private readonly IMapper _mapper;

        public RazasController(IServiciosRaza servicio, IServiciosTipoDeMascota serviciosTipoDeMascota)
        {
            _servicio = servicio;
            _serviciosTipoDeMascota = serviciosTipoDeMascota;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Razas
        public ActionResult Index(int? tipoDeMascotaSeleccionadaId=null, int? page=null)
        {
            page = (page ?? 1);
            //var listaDto = _servicio.GetLista(null);
            //var listaVm = _mapper.Map<List<RazaListViewModel>>(listaDto)
            //    .OrderBy(c => c.Descripcion)
            //    .ToPagedList((int)page, 5);
            //return View(listaVm);

            List<Raza> lista;

            if (tipoDeMascotaSeleccionadaId != null)
            {
                lista = _servicio.GetLista(tipoDeMascotaSeleccionadaId.Value);

            }
            else
            {
                lista = _servicio.GetLista();
            }

            if (tipoDeMascotaSeleccionadaId != null)
            {
                Session["tipoDeMascotaSeleccionadaId"] = tipoDeMascotaSeleccionadaId;
            }
            else
            {
                if (Session["tipoDeMascotaSeleccionadaId"] != null)
                {
                    tipoDeMascotaSeleccionadaId = (int)Session["tipoDeMascotaSeleccionadaId"];
                }
            }

            if (tipoDeMascotaSeleccionadaId != null)
            {
                if (tipoDeMascotaSeleccionadaId.Value > 0)
                {
                    lista = _servicio.GetLista(tipoDeMascotaSeleccionadaId.Value);
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
            var listaVm = _mapper.Map<List<RazaListViewModel>>(listaDto)

            .OrderBy(c => c.Descripcion)
            //.ThenBy(c => c.Provincia)
            .ToPagedList((int)page, 5);
            var listaVma = Mapeador.Mapeador.ConstruirListaRazaListVm(lista);
            var listaTipoDeMascotas = _serviciosTipoDeMascota.GetLista();
            listaTipoDeMascotas.Insert(0, new TipoDeMascotaListDto() { TipoDeMascotaId = 0, Descripcion = "[Seleccione un Tipo De Mascota]" });
            listaTipoDeMascotas.Insert(1, new TipoDeMascotaListDto() { TipoDeMascotaId = -1, Descripcion = "[Ver Todas]" });
            ViewBag.ListaTipoDeMascotas = new SelectList(listaTipoDeMascotas, "TipoDeMascotaId", "Descripcion", tipoDeMascotaSeleccionadaId);
            return View(listaVma.ToPagedList((int)page, 5));


        }

        [HttpGet]

        public ActionResult Create()
        {
            RazaEditViewModel razaVm = new RazaEditViewModel
            {
                TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista())

            };
            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(RazaEditViewModel razaEditVm)
        {
            if (!ModelState.IsValid)
            {
                razaEditVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
                return View(razaEditVm);
            }
            RazaEditDto razaDto = _mapper.Map<RazaEditDto>(razaEditVm);
            if (_servicio.Existe(razaDto))
            {
                ModelState.AddModelError(string.Empty, "Producto existente....");
                razaEditVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
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
                razaEditVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
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
            razaVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RazaEditViewModel razaVm)
        {
            if (!ModelState.IsValid)
            {
                razaVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
                return View(razaVm);
            }
            RazaEditDto razaDto = _mapper.Map<RazaEditDto>(razaVm);
            if (_servicio.Existe(razaDto))
            {
                ModelState.AddModelError(string.Empty, "Producto existente....");
                razaVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
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
                razaVm.TipoDeMascotas = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
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
            var razaDto = _servicio.GetRazaPorId(id);
            if (razaDto == null)
            {
                return HttpNotFound("Còdigo de Raza inexistente...");
            }
            RazaListViewModel razaVm = _mapper.Map<RazaListViewModel>(razaDto);
            razaVm.TipoDeMascota = (_serviciosTipoDeMascota.GetipoDeMascotaPorId(razaDto.TipoDeMascotaId)).Descripcion;
            return View(razaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(RazaEditViewModel razaVm)
        {
            RazaEditDto razaDto = _mapper.Map<RazaEditDto>(razaVm);
            if (_servicio.EstaRelacionado(razaDto))
            {
                ModelState.AddModelError(string.Empty, "Registro relacionado con otra tabla...Baja denegada");
                return View(razaVm);
            }
            try
            {
                RazaListDto raDto = _mapper.Map<RazaListDto>(_servicio.GetRazaPorId(razaVm.RazaId));
                razaVm = _mapper.Map<RazaEditViewModel>(_servicio.GetRazaPorId(razaVm.RazaId));
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
