using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Domain.Model.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string errorMessage) : base(errorMessage) { }
    }
}
