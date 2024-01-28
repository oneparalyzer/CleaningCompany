using AutoMapper;
using CleaningCompany.Contracts.Streets.Responses;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;

namespace CleaningCompany.Application.Common.Configurations.AutoMapper;

public sealed class StreetConfiguration : Profile
{
    public StreetConfiguration()
    {
        CreateMap<Street, GetAllStreetsResponse>()
            .ForPath(dst => dst.StreetId, opt => opt.MapFrom(src => src.Id.Value))
            .ForPath(dst => dst.CityId, opt => opt.MapFrom(src => src.CityId.Value));
    }
}
