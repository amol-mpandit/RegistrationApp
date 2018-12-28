using System.Threading.Tasks;

namespace ENotification
{
    public interface IENotificationService
    {
        Task SendMessage(string destination, string subject, string body);
    }
}
