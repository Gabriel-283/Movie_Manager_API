using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Login.Domain.Interfaces
{
    public interface ILogoutService
    {
        Result LogoutUser();
    }
}
