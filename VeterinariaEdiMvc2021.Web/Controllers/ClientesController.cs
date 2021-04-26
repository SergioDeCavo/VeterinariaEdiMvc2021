using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Cliente;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Provincia;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeDocumento;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IServiciosCliente _servicio;
        private readonly IServiciosTipoDeDocumento _serviciosTipoDeDocumento;
        private readonly IServiciosLocalidad _serviciosLocalidad;
        private readonly IServiciosProvincia _serviciosProvincia;
        private readonly IMapper _mapper;

        public ClientesController(IServiciosCliente servicio, IServiciosTipoDeDocumento serviciosTipoDeDocumento, IServiciosLocalidad serviciosLocalidad, IServiciosProvincia serviciosProvincia)
        {
            _servicio = servicio;
            _serviciosTipoDeDocumento = serviciosTipoDeDocumento;
            _serviciosLocalidad = serviciosLocalidad;
            _serviciosProvincia = serviciosProvincia;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Clientes
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<ClienteListViewModel>>(listaDto)
                .OrderBy(c=>c.Cliente)
                .ThenBy(c=>c.Localidad)
                .ToPagedList((int)page,5);
            return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create() 
        {
            ClienteEditViewModel clienteVm = new ClienteEditViewModel
            {
                TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista()),
                Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null)),
                Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista())
            };
            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Create(ClienteEditViewModel clienteEditVm) 
        {
            if (!ModelState.IsValid)
            {
                clienteEditVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                clienteEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                clienteEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(clienteEditVm);
            }
            ClienteEditDto clienteDto = _mapper.Map<ClienteEditDto>(clienteEditVm);
            if (_servicio.Existe(clienteDto))
            {
                ModelState.AddModelError(string.Empty, "Cliente Existente");
                clienteEditVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                clienteEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                clienteEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(clienteEditVm);

            }
            try
            {
                _servicio.Guardar(clienteDto);
                TempData["Msg"] = "Cliente Agregado....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                clienteEditVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                clienteEditVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                clienteEditVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(clienteEditVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id) 
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteEditDto clienteDto = _servicio.GetClientePorId(id);
            if (clienteDto==null)
            {
                return HttpNotFound("Còdigo de Cliente No Encontrado");
            }
            ClienteEditViewModel clienteVm = _mapper.Map<ClienteEditViewModel>(clienteDto);
            clienteVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
            clienteVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
            clienteVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteEditViewModel clienteVm) 
        {
            if (!ModelState.IsValid)
            {
                clienteVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                clienteVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                clienteVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(clienteVm);
            }
            ClienteEditDto clienteDto = _mapper.Map<ClienteEditDto>(clienteVm);
            if (_servicio.Existe(clienteDto))
            {
                ModelState.AddModelError(string.Empty, "Cliente Existente");
                clienteVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                clienteVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                clienteVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(clienteVm);

            }
            try
            {
                _servicio.Guardar(clienteDto);
                TempData["Msg"] = "Cliente Editado....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                clienteVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
                clienteVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                clienteVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(clienteVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id) 
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteDto = _servicio.GetClientePorId(id);
            if (clienteDto==null)
            {
                return HttpNotFound("Còdigo de Cliente inexistente");
            }
            
            ClienteListViewModel clienteVm = _mapper.Map<ClienteListViewModel>(clienteDto);
            clienteVm.Provincia = (_serviciosProvincia.GetProvinciaPorId(clienteDto.ProvinciaId)).NombreProvincia;
            clienteVm.Localidad= (_serviciosLocalidad.GetLocalidadPorId(clienteDto.LocalidadId)).NombreLocalidad;
            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteListViewModel clienteVm)
        {
            try
            {
                ClienteListDto clienteDto = _mapper.Map<ClienteListDto>(_servicio.GetClientePorId(clienteVm.ClienteId));
                clienteVm = _mapper.Map<ClienteListViewModel>(clienteDto);
                _servicio.Borrar(clienteVm.ClienteId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(clienteVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteEditDto clienteDto = _servicio.GetClientePorId(id);
            if (clienteDto == null)
            {
                return HttpNotFound("Còdigo de Cliente No Encontrado");
            }
            ClienteEditViewModel clienteVm = _mapper.Map<ClienteEditViewModel>(clienteDto);
            clienteVm.TipoDeDocumento = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipoDeDocumento.GetLista());
            clienteVm.Localidad = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
            clienteVm.Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
            return View(clienteVm);
        }
    }
}