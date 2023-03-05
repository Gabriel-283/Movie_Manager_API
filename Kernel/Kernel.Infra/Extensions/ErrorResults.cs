using FluentResults;
using Kernel.Domain.Model.Exceptions;

namespace Kernel.Infra.Extensions
{
    public class ErrorResults
    {
        public static Result GetInvalidUserResult()
        {
            return Result.Fail(new NotFoundUserException("Credenciais inválidas"));
        }

        public static Result GetNotFoundError(string errorMessage = "objeto não encontrado")
        {
            return Result.Fail(new NotFoundException(errorMessage));
        }

        public static Result GeBadRequestError(string errorMessage = "Favor validar request")
        {
            return Result.Fail(new BadRequestException(errorMessage));
        }
    }
}
