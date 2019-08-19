using Avaliacao.Application.Interfaces;
using Avaliacao.Application.Services;
using Avaliacao.Domain.CommandHandlers;
using Avaliacao.Domain.Commands;
using Avaliacao.Domain.Core.Bus;
using Avaliacao.Domain.EventHandlers;
using Avaliacao.Domain.Events;
using Avaliacao.Domain.Interfaces;
using Avaliacao.Infra.CrossCutting.Bus;
using Avaliacao.Infra.Data.Context;
using Avaliacao.Infra.Data.Repository;
using Avaliacao.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Avaliacao.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, bool>, ProductCommandHandler>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AvaliacaoContext>();
        }
    }
}
