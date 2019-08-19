using Avaliacao.Domain.Interfaces;
using Avaliacao.Domain.Models;
using Avaliacao.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AvaliacaoContext context)
            : base(context)
        {

        }
    }
}
