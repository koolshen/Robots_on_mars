using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using Robots_on_mars.Services;
using Robots_on_mars.Services.Interfaces;

namespace IoC
{
    public static class DependencyResolver 
    {
        private static readonly IKernel _ninjectResolver;

        static DependencyResolver()
        {
            _ninjectResolver = CreateKernel();
        }

        public static void InitIoC()
        {
            RegisterServices(_ninjectResolver);
        }

        public static T GetService<T>()
        {
            return _ninjectResolver.Get<T>();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            return kernel;
        }

        private static void RegisterServices(IBindingRoot kernel)
        {
            kernel.Rebind<IInputService>().To<InputService>();
            kernel.Rebind<IParsingService>().To<ParsingService>();
            kernel.Rebind<IInstructionService>().To<InstructionService>();
            kernel.Rebind<IValidationService>().To<ValidationService>();
        }

    }
}
