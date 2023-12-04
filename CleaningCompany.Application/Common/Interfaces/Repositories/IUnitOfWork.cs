namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IServiceRepository ServiceRepository { get; }
    IRegionRepository RegionRepository { get; }
    ICityRepository CityRepository { get; }
    IStreetRepository StreetRepository { get; }
    IAddressRepository AddressRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
