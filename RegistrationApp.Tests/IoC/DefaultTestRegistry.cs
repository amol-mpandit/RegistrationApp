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

            //For<IUserStore<ApplicationUser>>().Use(userStore);
            //For<UserManager<ApplicationUser>>().Use(userManager);
            var enotification = new EnotificationMock(new FakeWeb());
            For<EnotificationMock>().Use(enotification);
            For<IENotificationService>().Use(enotification);
        }
    }
}