using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.DTOs.MovieTheaterManager;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kernel.Domain.Interfaces;
using Movie.Domain.Interfaces;
using Movie.Domain.Interfaces.DaoInterfaces;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTheaterManagerController : AbstractController 
    {
        private IMovieTheaterManagerService _movieTheaterManagerService;

        public MovieTheaterManagerController(IMovieTheaterManagerService movieTheaterManagerService)
        {
            _movieTheaterManagerService = movieTheaterManagerService;
        }

        [HttpPost]
        public IActionResult AddMovieTheaterManager([FromBody] AddMovieTheaterManagerDto addMovieTheaterManagerDto)
        {
            var result = _movieTheaterManagerService.AddMovieTheaterManager(addMovieTheaterManagerDto);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieTheaterManagerById(int id)
        {
            var result = _movieTheaterManagerService.GetMovieTheaterManagerById(id);

            return result.IsSuccess ? Ok(result.Value) : GetErrorResult(result);
        }

        [HttpGet]
        public IActionResult GetMovieTheaterManagerList()
        {
            var result = _movieTheaterManagerService.GetMovieTheaterManagerList();

            return result.IsSuccess ? Ok(result.Value) : GetErrorResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieTheaterManagerById(int id, [FromBody] AddMovieTheaterManagerDto updateMovieTheaterDto)
        {
            
            var result = _movieTheaterManagerService.UpdateMovieTheaterManagerById(id, updateMovieTheaterDto);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieTheaterManagerById(int id)
        {
            var result = _movieTheaterManagerService.DeleteMovieTheaterManagerById(id);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }
    }
}
