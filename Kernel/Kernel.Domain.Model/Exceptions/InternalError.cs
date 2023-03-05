using System;
using FluentResults;

namespace Kernel.Domain.Model.Exceptions
{
    public class InternalException : BaseException
    {
        public InternalException(string errorMessage) : base(errorMessage)
        {
        }
    }
}