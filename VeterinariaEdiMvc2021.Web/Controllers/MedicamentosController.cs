using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.FormaFarmaceutica;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Laboratorio;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMedicamento;
using PagedList;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Web.Controllers
{
    public class MedicamentosController : Controller
    {
        private VeterinariaEdiMvc2021DbContext db = new VeterinariaEdiMvc2021DbContext();
        private readonly IServiciosMedicamento _servicio;
        private readonly IServiciosTipoDeMedicamento _serviciosTipoDeMedicamento;
        private readonly IServiciosFormaFarmaceutica _serviciosFormaFarmaceutica;
        private readonly IServiciosLaboratorio _serviciosLaboratorio;
        private readonly IMapper _mapper;

        public MedicamentosController(IServiciosMedicamento servicio, IServiciosTipoDeMedicamento serviciosTipoDeMedicamento, IServiciosFormaFarmaceutica serviciosFormaFarmaceutica, IServiciosLaboratorio serviciosLaboratorio)
        {
            _servicio = servicio;
            _serviciosTipoDeMedicamento = serviciosTipoDeMedicamento;
            _serviciosFormaFarmaceutica = serviciosFormaFarmaceutica;
            _serviciosLaboratorio = serviciosLaboratorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Empleados
        public ActionResult Index(int? tipoDeMedicamentoId=null, int? page=null)
        {
            page = (page ?? 1);
            var medicamentos = tipoDeMedicamentoId.HasValue
                ? db.Medicamentos.Where(t => t.TipoDeMedicamentoId == tipoDeMedicamentoId)
                : db.Medicamentos;
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<MedicamentoListViewModel>>(listaDto)
                .OrderBy(c => c.NombreComercial)
                .ToPagedList((int)page, 5);
            var listaTipo = db.TipoDeMedicamentos.ToList();
            listaTipo.Insert(0, new TipoDeMedicamento() { TipoDeMedicamentoId = 0, Descripcion = "[Seleccione Tipo De Medicamento]" });
            ViewBag.listaTipo = new SelectList(listaTipo, "TipoDeMedicamentoId", "Descripcion");
                return View(listaVm);
        }

        [HttpGet]

        public ActionResult Create()
        {
            MedicamentoEditViewModel medicamentoVm = new MedicamentoEditViewModel
            {
                TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista()),
                FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista()),
                Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista())
            };
            return View(medicamentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicamentoEditViewModel medicamentoEditVm)
        {
            if (!ModelState.IsValid)
            {
                medicamentoEditVm.TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista());
                medicamentoEditVm.FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista());
                medicamentoEditVm.Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista());
                return View(medicamentoEditVm);
            }
            MedicamentoEditDto medicamentoDto = _mapper.Map<MedicamentoEditDto>(medicamentoEditVm);
            if (_servicio.Existe(medicamentoDto))
            {
                ModelState.AddModelError(string.Empty, "Medicamento Existente");
                medicamentoEditVm.TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista());
                medicamentoEditVm.FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista());
                medicamentoEditVm.Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista());
                return View(medicamentoEditVm);

            }
            try
            {
                _servicio.Guardar(medicamentoDto);
                TempData["Msg"] = "Medicamento Agregado....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                medicamentoEditVm.TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista());
                medicamentoEditVm.FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista());
                medicamentoEditVm.Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista());
                return View(medicamentoEditVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentoEditDto medicamentoDto = _servicio.GetMedicamentoPorId(id);
            if (medicamentoDto == null)
            {
                return HttpNotFound("Còdigo de Medicamento No Encontrado");
            }
            MedicamentoEditViewModel medicamentoVm = _mapper.Map<MedicamentoEditViewModel>(medicamentoDto);
            medicamentoVm.TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista());
            medicamentoVm.FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista());
            medicamentoVm.Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista());
            return View(medicamentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicamentoEditViewModel medicamentoVm)
        {
            if (!ModelState.IsValid)
            {
                medicamentoVm.TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista());
                medicamentoVm.FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista());
                medicamentoVm.Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista());
                return View(medicamentoVm);
            }
            MedicamentoEditDto medicamentoDto = _mapper.Map<MedicamentoEditDto>(medicamentoVm);
            if (_servicio.Existe(medicamentoDto))
            {
                ModelState.AddModelError(string.Empty, "Medicamento Existente");
                medicamentoVm.TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista());
                medicamentoVm.FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista());
                medicamentoVm.Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista());
                return View(medicamentoVm);

            }
            try
            {
                _servicio.Guardar(medicamentoDto);
                TempData["Msg"] = "Medicamento Editado....";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                medicamentoVm.TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista());
                medicamentoVm.FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista());
                medicamentoVm.Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista());
                return View(medicamentoVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var medicamentoDto = _servicio.GetMedicamentoPorId(id);
            if (medicamentoDto == null)
            {
                return HttpNotFound("Còdigo de Medicamento inexistente");
            }
            MedicamentoListViewModel medicamentoVm = _mapper.Map<MedicamentoListViewModel>(medicamentoDto);
            medicamentoVm.TipoDeMedicamento = (_serviciosTipoDeMedicamento.GetipoDeMedicamentoPorId(medicamentoDto.TipoDeMedicamentoId)).Descripcion;
            medicamentoVm.FormaFarmaceutica = (_serviciosFormaFarmaceutica.GetFormaFarmaceuticaPorId(medicamentoDto.FormaFarmaceuticaId)).Descripcion;
            medicamentoVm.Laboratorio = (_serviciosLaboratorio.GetLaboratorioPorId(medicamentoDto.LaboratorioId)).Nombre;
            return View(medicamentoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MedicamentoListViewModel medicamentoVm)
        {
            try
            {
                MedicamentoListDto medicamentoDto = _mapper.Map<MedicamentoListDto>(_servicio.GetMedicamentoPorId(medicamentoVm.MedicamentoId));
                medicamentoVm = _mapper.Map<MedicamentoListViewModel>(medicamentoDto);
                _servicio.Borrar(medicamentoVm.MedicamentoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(medicamentoVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentoEditDto medicamentoDto = _servicio.GetMedicamentoPorId(id);
            if (medicamentoDto == null)
            {
                return HttpNotFound("Còdigo de Medicamento inexistente...");
            }
            MedicamentoEditViewModel medicamentoVm = _mapper.Map<MedicamentoEditViewModel>(medicamentoDto);
            medicamentoVm.TipoDeMedicamento = _mapper.Map<List<TipoDeMedicamentoListViewModel>>(_serviciosTipoDeMedicamento.GetLista());
            medicamentoVm.FormaFarmaceutica = _mapper.Map<List<FormaFarmaceuticaListViewModel>>(_serviciosFormaFarmaceutica.GetLista());
            medicamentoVm.Laboratorio = _mapper.Map<List<LaboratorioListViewModel>>(_serviciosLaboratorio.GetLista());
            return View(medicamentoVm);

        }
    }
}