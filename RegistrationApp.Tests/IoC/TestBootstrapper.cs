using RegistrationApp.DependencyResolution;
using StructureMap;

namespace RegistrationApp.Tests.IoC
{
    public static class TestBootstrapper 
    {
        public static IContainer Bootstrapper()
        {
            var container = new Container(c =>
            {
                c.AddRegistry<DefaultTestRegistry>();
            });
            return container;
        }
    }
}
