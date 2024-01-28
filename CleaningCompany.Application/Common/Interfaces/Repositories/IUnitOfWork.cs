namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IServiceRepository ServiceRepository { get; }
    IRegionRepository RegionRepository { get; }
    ICityRepository CityRepository { get; }
    IPriceListRepository PriceListRepository { get; }
    IStreetRepository StreetRepository { get; }
    IAddressRepository AddressRepository { get; }
    IOrderRepository OrderRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
