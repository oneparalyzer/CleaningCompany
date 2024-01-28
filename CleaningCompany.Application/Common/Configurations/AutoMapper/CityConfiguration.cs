using AutoMapper;
using CleaningCompany.Contracts.Cities.Responses;
using CleaningCompany.Domain.AggregateModels.CityAggregate;

namespace CleaningCompany.Application.Common.Configurations.AutoMapper;

public sealed class CityConfiguration : Profile
{
    public CityConfiguration()
    {
        CreateMap<City, GetAllCitiesResponse>()
            .ForPath(dst => dst.CityId, opt => opt.MapFrom(src => src.Id.Value))
            .ForPath(dst => dst.RegionId, opt => opt.MapFrom(src => src.RegionId.Value));
    }
}
