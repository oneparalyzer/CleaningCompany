using CleaningCompany.Domain.Common.Errors;

namespace CleaningCompany.Domain.Common.OperationResults;

public class Result
{
    protected Result(
        bool isSuccess,
        List<Error> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }
    public List<Error> Errors { get; }

    public static Result Success()
    {
        return new Result(true, new List<Error>());
    }

    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new Result<TValue>(
            value,
            true,
            new List<Error>());
    }

    public static Result Failure(List<Error> errors)
    {
        return new Result(false, errors);
    }

    public static Result<TValue> Failure<TValue>(List<Error> errors)
    {
        return new Result<TValue>(default, false, errors);
    }
}