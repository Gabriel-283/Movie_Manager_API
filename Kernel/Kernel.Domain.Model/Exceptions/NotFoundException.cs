using System;

namespace Kernel.Domain.Model.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string errorMessage) : base(errorMessage) { }
    }
}
