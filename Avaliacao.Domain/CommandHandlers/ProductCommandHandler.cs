using System;
using System.Threading;
using System.Threading.Tasks;
using Avaliacao.Domain.Commands;
using Avaliacao.Domain.Core.Bus;
using Avaliacao.Domain.Events;
using Avaliacao.Domain.Interfaces;
using Avaliacao.Domain.Models;
using MediatR;

namespace Avaliacao.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>,
        IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductCommandHandler(IProductRepository productRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus) : base(uow, bus)
        {
            _productRepository = productRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewProductCommand message, CancellationToken cancellationToken)
        {
            var product = new Product(Guid.NewGuid(), message.DataLancamento, message.Nome, message.TipoProduto, message.Valor);

            _productRepository.Add(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRegisteredEvent(product.Id, product.DataLancamento, product.Nome, product.TipoProduto, product.Valor));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            var product = new Product(message.Id, message.DataLancamento, message.Nome, message.TipoProduto, message.Valor);

            _productRepository.Update(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductUpdatedEvent(product.Id, product.DataLancamento, product.Nome, product.TipoProduto, product.Valor));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveProductCommand message, CancellationToken cancellationToken)
        {
            _productRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
