using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Movie.Login.API.Data.Requests;
using Kernel.Domain.Interfaces;
using Movie.Login.Domain.Interfaces;

namespace Movie.Login.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : AbstractController
    {
        private ILoginService   _loginService;
        private IPasswordService _passwordService;

        public LoginController(ILoginService loginService, IPasswordService passwordService)
        {
            _loginService = loginService;
            _passwordService = passwordService;
        }

        [HttpPost]
        public IActionResult LoginUser(LoginRequest request)
        {
            Result result = _loginService.LoginUser(request);

            return result.IsFailed ? GetErrorResult(result) : Ok(result);
        }
        
        [HttpPost("/password-reset")]
        public IActionResult ResetUsersPassword(ResetPasswordRequest request)
        {
            Result result = _passwordService.RequestPasswordReset(request);
            
            return result.IsFailed ? GetErrorResult(result) : Ok(result);
        }
        
        [HttpPost("/set-new-password")]
        public IActionResult SetUsersPassword(SetNewPasswordRequest request)
        {
            Result result = _passwordService.SetNewPassword(request);
            
            return result.IsFailed ? GetErrorResult(result) : Ok(result);
        }
    }
}
