using RegistrationApp.Tests.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Microsoft.AspNet.Identity;
using StructureMap;


namespace RegistrationApp.Tests.EnotificationTest
{
    [TestClass]
    public class EnotificationTest
    {
        private readonly IContainer _container;
        private readonly EmailService _emailService;
        private readonly FakeWeb fakeWebMail;
        public EnotificationTest()
        {
            _container = TestBootstrapper.Bootstrapper();
            _emailService = _container.GetInstance<EmailService>();
            fakeWebMail = _container.GetInstance<FakeWeb>();
        }

        [TestMethod]
        public void Normal_EmailTest()
        {
            var fakeMessage = new IdentityMessage
            {
                Destination = "Test@Test.com",
                Body = "Test Body"
            };
            var ExpectedResult = "Test@Test.com";
            var task = _emailService.SendAsync(fakeMessage);
            Assert.AreEqual(ExpectedResult, fakeWebMail.GetLastMessageDeliverdTo());
        }

        [TestMethod]
        public void Empty_Destination_Body_EmailTest()
        {
            var fakeMessage = new IdentityMessage
            {
                Destination = "",
                Body = ""
            };
            var ExpectedResult = "";
            var task = _emailService.SendAsync(fakeMessage);
            Assert.AreEqual(ExpectedResult, fakeWebMail.GetLastMessageDeliverdTo());
        }

        [TestMethod]
        public void Empty_Destination_EmailTest()
        {
            var fakeMessage = new IdentityMessage
            {
                Destination = "",
                Body = "Test Body"
            };
            var ExpectedResult = "";
            var task = _emailService.SendAsync(fakeMessage);
            Assert.AreEqual(ExpectedResult, fakeWebMail.GetLastMessageDeliverdTo());
        }

        [TestMethod]
        public void Empty_Body_EmailTest()
        {
            var fakeMessage = new IdentityMessage
            {
                Destination = "Test@Test.com",
                Body = ""
            };
            var ExpectedResult = "";
            var task = _emailService.SendAsync(fakeMessage);
            Assert.AreEqual(ExpectedResult, fakeWebMail.GetLastMessageDeliverdTo());
        }
    }
}
