using System;
using Avaliacao.Domain.Core.Models;

namespace Avaliacao.Domain.Models
{
    public class Product : Entity
    {
        public Product(Guid id, DateTime dataLancamento, string nome, string tipoProduto, decimal valor)
        {
            Id = id;
            DataLancamento = dataLancamento;
            Nome = nome;
            TipoProduto = tipoProduto;
            Valor = valor;
        }

        protected Product() { }

        public DateTime DataLancamento { get; private set; }

        public string Nome { get; private set; }

        public string TipoProduto { get; private set; }

        public decimal Valor { get; private set; }
    }
}
