using Ninject;
using System.Reflection;

namespace VeterinariaEdiMvc2021.Windows.Ninject
{
    public class DI
    {
        private static StandardKernel _kernel;
         public static void Initialize() 
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
        }

        public static T Create<T>() 
        {
            return _kernel.Get<T>();
        }
    }
}
