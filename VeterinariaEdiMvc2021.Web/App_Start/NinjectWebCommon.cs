[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VeterinariaEdiMvc2021.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VeterinariaEdiMvc2021.Web.App_Start.NinjectWebCommon), "Stop")]

namespace VeterinariaEdiMvc2021.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using VeterinariaEdiMvc.Servicios.Servicios;
    using VeterinariaEdiMvc.Servicios.Servicios.Facades;
    using VeterinariaEdiMvc2021.Datos;
    using VeterinariaEdiMvc2021.Datos.Repositorios;
    using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IServiciosDroga>().To<ServiciosDroga>().InRequestScope();
            kernel.Bind<IRepositorioDrogas>().To<RepositorioDrogas>().InRequestScope();

            kernel.Bind<IServiciosFormaFarmaceutica>().To<ServiciosFormaFarmaceutica>().InRequestScope();
            kernel.Bind<IRepositorioFormaFarmaceuticas>().To<RepositorioFormaFarmaceuticas>().InRequestScope();

            kernel.Bind<IServiciosLaboratorio>().To<ServiciosLaboratorio>().InRequestScope();
            kernel.Bind<IRepositorioLaboratorios>().To<RepositorioLaboratorios>().InRequestScope();

            kernel.Bind<IServiciosProvincia>().To<ServiciosProvincia>().InRequestScope();
            kernel.Bind<IRepositorioProvincias>().To<RepositorioProvincias>().InRequestScope();

            kernel.Bind<IServiciosTipoDeDocumento>().To<ServiciosTipoDeDocumento>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeDocumentos>().To<RepositorioTipoDeDocumentos>().InRequestScope();

            kernel.Bind<IServiciosTipoDeMascota>().To<ServiciosTipoDeMascota>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeMascotas>().To<RepositorioTipoDeMascotas>().InRequestScope();

            kernel.Bind<IServiciosTipoDeMedicamento>().To<ServiciosTipoDeMedicamento>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeMedicamentos>().To<RepositorioTipoDeMedicamentos>().InRequestScope();

            kernel.Bind<IServiciosTipoDeServicio>().To<ServiciosTipoDeServicio>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeServicios>().To<RepositorioTipoDeServicios>().InRequestScope();

            kernel.Bind<IServiciosTipoDeTarea>().To<ServiciosTipoDeTarea>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeTareas>().To<RepositorioTipoDeTareas>().InRequestScope();

            kernel.Bind<IServiciosRaza>().To<ServiciosRaza>().InRequestScope();
            kernel.Bind<IRepositorioRazas>().To<RepositorioRazas>().InRequestScope();

            kernel.Bind<IServiciosLocalidad>().To<ServiciosLocalidad>().InRequestScope();
            kernel.Bind<IRepositorioLocalidades>().To<RepositorioLocalidades>().InRequestScope();

            kernel.Bind<IServiciosCliente>().To<ServiciosCliente>().InRequestScope();
            kernel.Bind<IRepositorioClientes>().To<RepositorioClientes>().InRequestScope();

            kernel.Bind<IServiciosEmpleado>().To<ServiciosEmpleado>().InRequestScope();
            kernel.Bind<IRepositorioEmpleados>().To<RepositorioEmpleados>().InRequestScope();

            kernel.Bind<IServiciosMascota>().To<ServiciosMascota>().InRequestScope();
            kernel.Bind<IRepositorioMascotas>().To<RepositorioMascotas>().InRequestScope();

            kernel.Bind<IServiciosMedicamento>().To<ServiciosMedicamento>().InRequestScope();
            kernel.Bind<IRepositorioMedicamentos>().To<RepositorioMedicamentos>().InRequestScope();

            kernel.Bind<IServiciosProveedor>().To<ServiciosProveedor>().InRequestScope();
            kernel.Bind<IRepositorioProveedores>().To<RepositorioProveedores>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(VeterinariaEdiMvc2021DbContext)).ToSelf().InSingletonScope();
        }
    }
}