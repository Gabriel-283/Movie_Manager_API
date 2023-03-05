using FluentResults;

namespace Kernel.Domain.Model.Exceptions
{
    public class BaseException : Error
    {
        public BaseException(string errorMessage) : base(errorMessage){}
    }
}