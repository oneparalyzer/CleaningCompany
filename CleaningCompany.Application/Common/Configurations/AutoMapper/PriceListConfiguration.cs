using AutoMapper;
using CleaningCompany.Contracts.PriceLists.Responses;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate;

namespace CleaningCompany.Application.Common.Configurations.AutoMapper;

public sealed class PriceListConfiguration : Profile
{
    public PriceListConfiguration()
    {
        CreateMap<PriceList, GetAllPriceListsResponse>()
            .ForPath(dst => dst.PriceListId, opt => opt.MapFrom(src => src.Id.Value))
            .ForPath(dst => dst.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
    }
}
