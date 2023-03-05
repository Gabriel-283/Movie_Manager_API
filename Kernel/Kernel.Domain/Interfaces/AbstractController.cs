using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Kernel.Domain.Interfaces
{
    public abstract class AbstractController : ControllerBase
    {
        protected IActionResult GetErrorResult(Result result)
        {
            if (result.HasError<InternalException>())
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else if (result.HasError<NotFoundException>())
            {
                return NotFound(result.Reasons);
            }
            else if (result.HasError<NotFoundUserException>())
            {
                return Unauthorized(result.Reasons);
            }
            else if (result.HasError<BadRequestException>())
            {
                return BadRequest(result.Errors);
            }

            return BadRequest(result.Errors);
        }
    }
}