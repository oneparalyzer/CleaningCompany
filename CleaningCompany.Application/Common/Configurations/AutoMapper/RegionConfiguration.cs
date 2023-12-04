using AutoMapper;
using CleaningCompany.Contracts.Regions.Responses;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;

namespace CleaningCompany.Application.Common.Configurations.AutoMapper;

public sealed class RegionConfiguration : Profile
{
    public RegionConfiguration()
    {
        CreateMap<Region, GetAllRegionsResponse>()
            .ForPath(dst => dst.RegionId, opt => opt.MapFrom(src => src.Id.Value));
    }
}
