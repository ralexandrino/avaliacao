using AutoMapper;
using Avaliacao.Application.ViewModels;
using Avaliacao.Domain.Commands;

namespace Avaliacao.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(c => new RegisterNewProductCommand(c.DataLancamento, c.Nome, c.TipoProduto, c.Valor));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(c.Id, c.DataLancamento, c.Nome, c.TipoProduto, c.Valor));
        }
    }
}
