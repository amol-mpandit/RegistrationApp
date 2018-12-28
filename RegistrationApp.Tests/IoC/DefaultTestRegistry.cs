using ENotification;
using Microsoft.AspNet.Identity;
using Moq;
using RegistrationApp.Models;
using RegistrationApp.Tests.EnotificationTest;
using SendGrid;
using StructureMap;

namespace RegistrationApp.Tests.IoC
{
    public class DefaultTestRegistry : Registry
    {
        public DefaultTestRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AssembliesAndExecutablesFromApplicationBaseDirectory();
                });
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new UserManager<ApplicationUser>(userStore.Object);

            var fakeWeb = new FakeWeb();
            For<FakeWeb>().Use(fakeWeb);
            For<ITransport>().Use(fakeWeb);
        }
    }
}