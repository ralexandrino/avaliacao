using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao.Domain.Commands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, DateTime dataLancamento, string nome, string tipoProduto, decimal valor)
        {
            Id = id;
            DataLancamento = dataLancamento;
            Nome = nome;
            TipoProduto = tipoProduto;
            Valor = valor;
        }
    }
}
