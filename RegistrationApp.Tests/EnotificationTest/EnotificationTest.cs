using Moq;
using RegistrationApp.Controllers;
using RegistrationApp.Tests.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Microsoft.AspNet.Identity;
using RegistrationApp.Models;
using ENotification;

namespace RegistrationApp.Tests.EnotificationTest
{
    [TestClass]
    public class EnotificationTest
    {
        [TestMethod]
        public void EmailTest()
        {
            var container = TestBootstrapper.Bootstrapper();
            var user = new RegisterViewModel
            {
                Email = "abc@abc.com"
            };
            
            var mailService = container.GetInstance<EmailService>();
            var fakeWebMail = container.GetInstance<EnotificationMock>();
            var fakeMessage = new IdentityMessage
            {
                Destination = "abc@abc.com"
            };

            var task = mailService.SendAsync(fakeMessage);
            Assert.AreEqual(fakeMessage.Destination, fakeWebMail.GetLastMessageDeliverdTo());
        }
    }
}
