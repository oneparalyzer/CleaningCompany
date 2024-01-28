using CleaningCompany.Application.Common.Interfaces.Repositories;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(
        ApplicationDbContext context,
        IUserRepository userRepository, 
        IServiceRepository serviceRepository, 
        IRegionRepository regionRepository, 
        ICityRepository cityRepository, 
        IStreetRepository streetRepository, 
        IAddressRepository addressRepository,
        IPriceListRepository priceListRepository,
        IOrderRepository orderRepository)
    {
        _context = context;
        UserRepository = userRepository;
        ServiceRepository = serviceRepository;
        RegionRepository = regionRepository;
        CityRepository = cityRepository;
        StreetRepository = streetRepository;
        AddressRepository = addressRepository;
        PriceListRepository = priceListRepository;
        OrderRepository = orderRepository;
    }

    public IUserRepository UserRepository { get; }
    public IServiceRepository ServiceRepository { get; }
    public IRegionRepository RegionRepository { get; }
    public ICityRepository CityRepository { get; }
    public IStreetRepository StreetRepository { get; }
    public IAddressRepository AddressRepository { get; }
    public IPriceListRepository PriceListRepository { get; }
    public IOrderRepository OrderRepository { get; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
