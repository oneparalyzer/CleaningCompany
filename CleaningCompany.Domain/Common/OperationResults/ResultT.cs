using CleaningCompany.Domain.Common.Errors;

namespace CleaningCompany.Domain.Common.OperationResults;

public class Result<TValue> : Result
{
    protected internal Result(
        TValue value,
        bool isSuccess,
        List<Error> errors)
        : base(
            isSuccess,
            errors)
    {
        Value = value;
    }

    public static implicit operator Result<TValue>(TValue value)
    {
        return Success(value);
    }

    public TValue Value { get; }
}
