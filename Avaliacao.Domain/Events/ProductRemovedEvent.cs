using Avaliacao.Domain.Core.Events;
using System;

namespace Avaliacao.Domain.Events
{
    public class ProductRemovedEvent : Event
    {
        public ProductRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
