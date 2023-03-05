using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.DTOs.MovieTheater;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kernel.Domain.Interfaces;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.DTOs.Session;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : AbstractController
    {
        private ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public IActionResult AddSession([FromBody] AddSessionDto addSessionDto)
        {
            var result = _sessionService.AddSession(addSessionDto);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            var result = _sessionService.GetSessionById(id);

            return result.IsSuccess ? Ok(result.Value) : GetErrorResult(result);
        }

        [HttpGet]
        public IActionResult GetSessionList()
        {
            var result = _sessionService.GetSessionList();

            return result.IsSuccess ? Ok(result.Value) : GetErrorResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSessionDto updateSessionDto)
        {
            var result = _sessionService.UpdateSessionById(id, updateSessionDto);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _sessionService.DeleteSessionsById(id);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }
    }
}