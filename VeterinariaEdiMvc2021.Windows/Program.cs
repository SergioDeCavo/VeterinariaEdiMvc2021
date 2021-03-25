using System;
using System.Windows.Forms;
using VeterinariaEdiMvc2021.Windows.Mapeador;
using VeterinariaEdiMvc2021.Windows.Ninject;

namespace VeterinariaEdiMvc2021.Windows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DI.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoMapperConfig.Init();
            Application.Run(DI.Create<frmMenuPrincipal>());
        }
    }
}
