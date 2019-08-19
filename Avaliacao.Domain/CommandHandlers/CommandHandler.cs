using Avaliacao.Domain.Core.Bus;
using Avaliacao.Domain.Interfaces;

namespace Avaliacao.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus)
        {
            _uow = uow;
            _bus = bus;
        }

        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }
    }
}
