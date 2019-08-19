using Avaliacao.Domain.Interfaces;
using Avaliacao.Infra.Data.Context;

namespace Avaliacao.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AvaliacaoContext _context;

        public UnitOfWork(AvaliacaoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
