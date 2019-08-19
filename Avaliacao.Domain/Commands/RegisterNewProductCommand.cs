using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao.Domain.Commands
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand(DateTime dataLancamento, string nome, string tipoProduto, decimal valor)
        {
            DataLancamento = dataLancamento;
            Nome = nome;
            TipoProduto = tipoProduto;
            Valor = valor;
        }
    }
}
