using SendGrid;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ENotification
{
    public class ENotificationService : IENotificationService
    {
        public readonly ITransport _web;
        public readonly MailAddress From;
        public ENotificationService(ITransport transport)
        {
            _web = transport;
            From = new MailAddress("Admin@UserService.com", "Admin User");
        }

        public Task SendMessage(string destination, string subject, string body) 
        {
            if(string.IsNullOrEmpty(destination) || string.IsNullOrEmpty(body))
            {
                return Task.FromResult(0);
            }
            var message = new SendGridMessage();
            
            message.AddTo(destination);
            message.AddBcc("amol.mpandit@gmail.com");
            message.From = From;
            message.Subject = subject;
            message.Text = body;
            message.Html = body;

            return _web.DeliverAsync(message);
        }
    }
}
