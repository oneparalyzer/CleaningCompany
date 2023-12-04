using CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.Errors;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.SeedWorks;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Domain.AggregateModels.PriceListAggregate;

public sealed class PriceList : AggregateRoot<PriceListId>
{
    private Guid _employeeId;

    private readonly List<PriceListPosition> _positions;

    private PriceList(PriceListId id) : base(id) { }

    private PriceList(
        PriceListId id, 
        UserId employeeId, 
        DateTime createdDate, 
        List<PriceListPosition> positions) : base(id)
    {
        EmployeeId = employeeId;
        CreatedDate = createdDate;
        _positions = positions;
    }

    public UserId EmployeeId
    {
        get => UserId.Create(_employeeId); 
        private set => _employeeId = value.Value; 
    }

    public DateTime CreatedDate { get; private set; }
    public IReadOnlyList<PriceListPosition> Positions => _positions.AsReadOnly();

    public static Result<PriceList> Create(
        UserId employeeId, 
        List<PriceListPosition> positions)
    {
        Result validatePositionsResult = ValidatePositions(positions);
        if (!validatePositionsResult.IsSuccess)
        {
            return Result.Failure<PriceList>(
                validatePositionsResult.Errors);
        }

        var priceList = new PriceList(
            PriceListId.Create(),
            employeeId,
            DateTime.Now,
            positions);

        return Result.Success(priceList);
    }

    private static Result ValidatePositions(List<PriceListPosition> positions)
    {
        var errors = new List<Error>();
        var positionsHashSet = new HashSet<PriceListPosition>();

        foreach (var position in positions)
        {
            if (!positionsHashSet.Add(position))
            {
                errors.Add(Errors.PriceListPosition
                    .CannotBeRepeatedByServiceId(position.ServiceId.ToString()));
            }
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        return Result.Success();
    }
}
