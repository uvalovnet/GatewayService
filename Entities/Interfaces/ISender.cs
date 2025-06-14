
using Entities.Requests.Account;
using Entities.Requests.Game;
using Entities.Requests.Pay;

namespace Entities.Interfaces
{
    public interface ISender
    {
        Task SendAsync<T>(string topicName, T message);
    }
}
