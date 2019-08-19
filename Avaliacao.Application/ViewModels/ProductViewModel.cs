using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Avaliacao.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Nome { get; set; }

        public string TipoProduto { get; set; }

        public decimal Valor { get; set; }
    }
}
