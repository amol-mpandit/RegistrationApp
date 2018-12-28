using ENotification;
using SendGrid;
using System.Threading.Tasks;

namespace RegistrationApp.Tests.EnotificationTest
{
    //public class EnotificationMock : IENotificationService
    //{
    //    private readonly FakeWeb web;
        
    //    public EnotificationMock(FakeWeb fakeweb)
    //    {
    //        web = fakeweb;
    //    }
    //    public string GetLastMessageDeliverdTo()
    //    {
    //        return web.LastMessageDeliverd();
    //    }
    //    public Task SendMessage(string destination, string subject, string body)
    //    {
    //        var message = new SendGridMessage();
    //        message.AddTo(destination);
    //        message.Subject = subject;
    //        message.Text = body;
    //        message.Html = body;
    //        return web.DeliverAsync(message);
    //    }
    //}
    public class FakeWeb : ITransport
    {
        private string LastMessageDeliverdTo = string.Empty;

        public void Deliver(ISendGrid message)
        {
        }

        public Task DeliverAsync(ISendGrid message)
        {
            LastMessageDeliverdTo = string.Empty;
            foreach (var to in message.To)
                LastMessageDeliverdTo += to;
            return Task.FromResult(0);
        }

        public string LastMessageDeliverd()
        {
            return LastMessageDeliverdTo;
        }

        public string GetLastMessageDeliverdTo()
        {
            return LastMessageDeliverdTo;
        }
    }       
}
