using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class User
    {
        public static Error CannotBeIdentified() => new Error(
            code: "User.CannotBeIdentified",
            message: "Пользователь не идентефицирован.");

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

        public static Error NotFoundById(string fieldValue) => new Error(
            code: "User.NotFoundById",
            message: "Прайс-лист не найдена.",
            field: "userId",
            fieldValue: fieldValue);
    }
}
