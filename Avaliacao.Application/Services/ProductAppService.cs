using AutoMapper;
using AutoMapper.QueryableExtensions;
using Avaliacao.Application.Interfaces;
using Avaliacao.Application.ViewModels;
using Avaliacao.Domain.Core.Bus;
using Avaliacao.Domain.Interfaces;
using Avaliacao.Domain.Commands;
using System;
using System.Collections.Generic;

namespace Avaliacao.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductAppService(IMapper mapper,
                                  IProductRepository productRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            Bus = bus;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _productRepository.GetAll().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public void Register(ProductViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ProductViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
