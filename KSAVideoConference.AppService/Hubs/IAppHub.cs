using System.Threading.Tasks;

namespace KSAVideoConference.AppService.Hubs
{
    public interface IAppHub
    {
        Task Send(string message);
    }
}
