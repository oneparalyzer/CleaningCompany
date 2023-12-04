using CleaningCompany.Domain.AggregateModels.UserAggregate;

namespace CleaningCompany.Application.Common.Interfaces.Autorization;

public interface IJwtTokenGenerator
{
    string Generate(User user);
}
