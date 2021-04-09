using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc.Servicios.Servicios;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;

namespace VeterinariaEdiMvc2021.Windows.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load() 
        {
            
            Bind<VeterinariaEdiMvc2021DbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositorioDrogas>().To<RepositorioDrogas>();
            Bind<IServiciosDroga>().To<ServiciosDroga>();

            Bind<IRepositorioFormaFarmaceuticas>().To<RepositorioFormaFarmaceuticas>();
            Bind<IServiciosFormaFarmaceutica>().To<ServiciosFormaFarmaceutica>();

            Bind<IRepositorioLaboratorios>().To<RepositorioLaboratorios>();
            Bind<IServiciosLaboratorio>().To<ServiciosLaboratorio>();

            Bind<IRepositorioProvincias>().To<RepositorioProvincias>();
            Bind<IServiciosProvincia>().To<ServiciosProvincia>();

            Bind<IRepositorioTipoDeDocumentos>().To<RepositorioTipoDeDocumentos>();
            Bind<IServiciosTipoDeDocumento>().To<ServiciosTipoDeDocumento>();

            Bind<IRepositorioTipoDeMascotas>().To<RepositorioTipoDeMascotas>();
            Bind<IServiciosTipoDeMascota>().To<ServiciosTipoDeMascota>();

            Bind<IRepositorioTipoDeMedicamentos>().To<RepositorioTipoDeMedicamentos>();
            Bind<IServiciosTipoDeMedicamento>().To<ServiciosTipoDeMedicamento>();

            Bind<IRepositorioTipoDeServicios>().To<RepositorioTipoDeServicios>();
            Bind<IServiciosTipoDeServicio>().To<ServiciosTipoDeServicio>();

            Bind<IRepositorioTipoDeTareas>().To<RepositorioTipoDeTareas>();
            Bind<IServiciosTipoDeTarea>().To<ServiciosTipoDeTarea>();

            Bind<IRepositorioLocalidades>().To<RepositorioLocalidades>();
            Bind<IServiciosLocalidad>().To<ServiciosLocalidad>();

            Bind<IRepositorioRazas>().To<RepositorioRazas>();
            Bind<IServiciosRaza>().To<ServiciosRaza>();

        }
    }
}
