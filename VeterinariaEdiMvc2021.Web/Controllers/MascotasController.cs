using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Mascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Cliente;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Mascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Raza;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class MascotasController : Controller
    {
        private readonly IServiciosMascota _servicio;
        private readonly IServiciosTipoDeMascota _serviciosTipoDeMascota;
        private readonly IServiciosRaza _serviciosRaza;
        private readonly IServiciosCliente _serviciosCliente;
        private readonly IMapper _mapper;

        public MascotasController(IServiciosMascota servicio, IServiciosTipoDeMascota serviciosTipoDeMascota, IServiciosRaza serviciosRaza, IServiciosCliente serviciosCliente)
        {
            _servicio = servicio;
            _serviciosTipoDeMascota = serviciosTipoDeMascota;
            _serviciosRaza = serviciosRaza;
            _serviciosCliente= serviciosCliente;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Empleados
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<MascotaListViewModel>>(listaDto)
                .OrderBy(c => c.Nombre)
                .ToPagedList((int)page, 5);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            MascotaEditViewModel mascotaVm = new MascotaEditViewModel
            {
                TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista()),
                Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null)),
                Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null))
            };
            return View(mascotaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MascotaEditViewModel mascotaEditVm)
        {
            if (!ModelState.IsValid)
            {
                mascotaEditVm.TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
                mascotaEditVm.Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null));
                mascotaEditVm.Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null));
                return View(mascotaEditVm);
            }
            MascotaEditDto mascotaDto = _mapper.Map<MascotaEditDto>(mascotaEditVm);
            if (_servicio.Existe(mascotaDto))
            {
                ModelState.AddModelError(string.Empty, "Mascota Existente");
                mascotaEditVm.TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
                mascotaEditVm.Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null));
                mascotaEditVm.Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null));
                return View(mascotaEditVm);

            }
            try
            {
                _servicio.Guardar(mascotaDto);
                TempData["Msg"] = "Mascota Agregada....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                mascotaEditVm.TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
                mascotaEditVm.Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null));
                mascotaEditVm.Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null));
                return View(mascotaEditVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MascotaEditDto mascotaDto = _servicio.GetMascotaPorId(id);
            if (mascotaDto == null)
            {
                return HttpNotFound("Còdigo de Mascota No Encontrado");
            }
            MascotaEditViewModel mascotaVm = _mapper.Map<MascotaEditViewModel>(mascotaDto);
            mascotaVm.TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
            mascotaVm.Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null));
            mascotaVm.Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null));
            return View(mascotaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MascotaEditViewModel mascotaVm)
        {
            if (!ModelState.IsValid)
            {
                mascotaVm.TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
                mascotaVm.Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null));
                mascotaVm.Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null));
                return View(mascotaVm);
            }
            MascotaEditDto mascotaDto = _mapper.Map<MascotaEditDto>(mascotaVm);
            if (_servicio.Existe(mascotaDto))
            {
                ModelState.AddModelError(string.Empty, "Mascota Existente");
                mascotaVm.TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
                mascotaVm.Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null));
                mascotaVm.Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null));
                return View(mascotaVm);

            }
            try
            {
                _servicio.Guardar(mascotaDto);
                TempData["Msg"] = "Mascota Editada....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                mascotaVm.TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
                mascotaVm.Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null));
                mascotaVm.Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null));
                return View(mascotaVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mascotaDto = _servicio.GetMascotaPorId(id);
            if (mascotaDto == null)
            {
                return HttpNotFound("Còdigo de Mascota inexistente");
            }
            MascotaListViewModel mascotaVm = _mapper.Map<MascotaListViewModel>(mascotaDto);
            mascotaVm.TipoDeMascota = (_serviciosTipoDeMascota.GetipoDeMascotaPorId(mascotaDto.TipoDeMascotaId)).Descripcion;
            mascotaVm.Raza = (_serviciosRaza.GetRazaPorId(mascotaDto.RazaId)).Descripcion;
            mascotaVm.Cliente = (_serviciosCliente.GetClientePorId(mascotaDto.ClienteId)).Apellido;
            return View(mascotaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MascotaListViewModel mascotaVm)
        {
            try
            {
                MascotaListDto mascotaDto = _mapper.Map<MascotaListDto>(_servicio.GetMascotaPorId(mascotaVm.MascotaId));
                mascotaVm = _mapper.Map<MascotaListViewModel>(mascotaDto);
                _servicio.Borrar(mascotaVm.MascotaId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(mascotaVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MascotaEditDto mascotaDto = _servicio.GetMascotaPorId(id);
            if (mascotaDto == null)
            {
                return HttpNotFound("Còdigo de Mascota No Encontrado");
            }
            MascotaEditViewModel mascotaVm = _mapper.Map<MascotaEditViewModel>(mascotaDto);
            mascotaVm.TipoDeMascota = _mapper.Map<List<TipoDeMascotaListViewModel>>(_serviciosTipoDeMascota.GetLista());
            mascotaVm.Raza = _mapper.Map<List<RazaListViewModel>>(_serviciosRaza.GetLista(null));
            mascotaVm.Cliente = _mapper.Map<List<ClienteListViewModel>>(_serviciosCliente.GetLista(null));
            return View(mascotaVm);
        }

            
    }
}