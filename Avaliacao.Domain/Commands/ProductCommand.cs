using System;
using Avaliacao.Domain.Core.Commands;

namespace Avaliacao.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }

        public DateTime DataLancamento { get; protected set; }

        public string Nome { get; protected set; }

        public string TipoProduto { get; protected set; }

        public decimal Valor { get; protected set; }
    }
}
