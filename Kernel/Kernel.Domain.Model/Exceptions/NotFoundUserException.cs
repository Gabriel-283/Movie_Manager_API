namespace Kernel.Domain.Model.Exceptions
{
    public class NotFoundUserException : BaseException
    {
        public NotFoundUserException(string errorMessage) : base(errorMessage)
        {
        }
    }
}