using TitleSearch.Application.Notifications.Models;
using System.Threading.Tasks;

namespace TitleSearch.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}