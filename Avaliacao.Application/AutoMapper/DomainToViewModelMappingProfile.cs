using AutoMapper;
using Avaliacao.Application.ViewModels;
using Avaliacao.Domain.Models;

namespace Avaliacao.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
