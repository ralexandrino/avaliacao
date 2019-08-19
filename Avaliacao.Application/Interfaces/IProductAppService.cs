using System;
using System.Collections.Generic;
using Avaliacao.Application.ViewModels;

namespace Avaliacao.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Register(ProductViewModel customerViewModel);
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetById(Guid id);
        void Update(ProductViewModel customerViewModel);
        void Remove(Guid id);
    }
}
