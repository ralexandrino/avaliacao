using Avaliacao.Domain.Core.Events;
using System;

namespace Avaliacao.Domain.Events
{
    public class ProductUpdatedEvent : Event
    {
        public ProductUpdatedEvent(Guid id, DateTime dataLancamento, string nome, string tipoProduto, decimal valor)
        {
            Id = id;
            DataLancamento = dataLancamento;
            Nome = nome;
            TipoProduto = tipoProduto;
            Valor = valor;
        }
        public Guid Id { get; set; }

        public DateTime DataLancamento { get; private set; }

        public string Nome { get; private set; }

        public string TipoProduto { get; private set; }

        public decimal Valor { get; private set; }
    }
}
