using System.Threading.Tasks;
using Avaliacao.Domain.Core.Commands;
using Avaliacao.Domain.Core.Events;

namespace Avaliacao.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
