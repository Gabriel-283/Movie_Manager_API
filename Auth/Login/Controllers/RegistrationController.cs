using FluentResults;
using Kernel.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Movie.Login.API.Data.DTOs;
using Movie.Login.API.Data.Requests;
using Movie.Login.Domain.Interfaces;

namespace Movie.Login.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : AbstractController
    {
        private IRegisterService _registerService;

        public RegistrationController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public IActionResult CreateUser(CreaterUserDto createUserDto)
        {
            Result result = _registerService.RegisterUser(createUserDto);

            return result.IsFailed ? GetErrorResult(result) : Ok(result.Successes);
        }

        [HttpGet("/activate")]
        public IActionResult ActivateUser([FromQuery]ActivateUserRequest request)
        {
            Result result = _registerService.ActivateUSer(request);

            return result.IsFailed ? GetErrorResult(result) : Ok(result.Successes);
        }
    }
}