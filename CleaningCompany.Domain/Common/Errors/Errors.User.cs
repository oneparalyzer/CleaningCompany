using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class User
    {
        public static Error AlreadyExistByEmail(string fieldValue) => new Error(
            code: "User.AlreadyExistByEmail",
            message: "Пользователь с таким Email уже существует.",
            field: "email",
            fieldValue: fieldValue);

        public static Error AlreadyExistByUserName(string fieldValue) => new Error(
            code: "User.AlreadyExistByUserName",
            message: "Пользователь с таким именем пользователя уже существует.",
            field: "userName",
            fieldValue: fieldValue);

        public static Error InvalidCredentionals => new Error(
            code: "User.InvalidCredentionals",
            message: "Не верный Email или пароль.",
            field: "userName");
    }
}
