using AutoMapper;
using CleaningCompany.Contracts.Addresses.Responses;
using CleaningCompany.Domain.AggregateModels.AddressAggregate;

namespace CleaningCompany.Application.Common.Configurations.AutoMapper;

public sealed class AddressConfiguration : Profile
{
    public AddressConfiguration()
    {
        CreateMap<Address, GetAllAddressesResponse>()
            .ForPath(dst => dst.AddressId, opt => opt.MapFrom(dst => dst.Id.Value))
            .ForPath(dst => dst.StreetId, opt => opt.MapFrom(dst => dst.StreetId.Value));
    }
}
