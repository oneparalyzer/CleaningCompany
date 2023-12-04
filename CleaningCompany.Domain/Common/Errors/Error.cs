using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.Common.Errors;

public sealed class Error : ValueObject
{
    public Error(
        string code,
        string message,
        string? field = null,
        string? fieldValue = null)
    {
        Code = code;
        Message = message;
        Field = field ?? string.Empty;
        FieldValue = fieldValue ?? string.Empty;
    }

    public string Code { get; }
    public string? Field { get; }
    public string? FieldValue { get; }
    public string Message { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Message;
        yield return Field;
        yield return FieldValue;
    }
    public static Error Unknown =>
        new Error(
            "UnknownError",
            "Произошла ошибка");

    public List<Error> ToList()
    {
        return new List<Error>
        {
            this
        };
    }
}
