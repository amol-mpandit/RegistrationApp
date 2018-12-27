using SendGrid;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ENotification
{
    public class EnotificationService
    {
        public readonly Web _web;
        public readonly MailAddress From;
        public EnotificationService(NetworkCredential networkCredential)
        {
            _web = new Web(networkCredential);
            From = new MailAddress("Admin@UserService.com", "Admin User");
        }

        public Task SendMessage(string destination, string subject, string body) 
        {
            var message = new SendGridMessage();
            message.AddTo(destination);
            message.From = From;
            message.Subject = subject;
            message.Text = body;
            message.Html = body;

            return _web.DeliverAsync(message);
        }
    }
}
