using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Kernel.Domain.Interfaces;
using Movie.Login.API.Services;
using Movie.Login.Domain.Interfaces;

namespace Movie.Login.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : AbstractController
    {
        private ILogoutService _logoutService;

        public LogoutController(ILogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult LogoutUser()
        {
            Result result= _logoutService.LogoutUser();

            return result.IsFailed ? GetErrorResult(result) : Ok(); 
        }
    }
}
