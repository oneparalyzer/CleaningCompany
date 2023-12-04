using AutoMapper;
using CleaningCompany.Contracts.Services.Responses;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;

namespace CleaningCompany.Application.Common.Configurations.AutoMapper;

public class ServiceConfiguration : Profile
{
    public ServiceConfiguration()
    {
        CreateMap<Service, GetAllServicesResponse>()
            .ForPath(dst => dst.Id, opt => opt.MapFrom(src => src.Id.Value));
    }
}
