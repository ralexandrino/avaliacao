using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao.Domain.Commands
{
    public class RemoveProductCommand : ProductCommand
    {
        public RemoveProductCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
