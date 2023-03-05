using AutoMapper;
using Kernel.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Interfaces;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.DTOs.MovieTheater;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTheaterController : AbstractController
    {
        private IMovieTheaterService _movieTheaterService;

        public MovieTheaterController(IMovieTheaterService movieTheaterService, IMovieTheaterDao dao, IMapper mapper)
        {
            _movieTheaterService = movieTheaterService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMovieTheater([FromBody] AddMovieTheaterDto movieTheaterDto)
        {
            var result = _movieTheaterService.AddMovieTheater(movieTheaterDto);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieTheaterById(int id)
        {
            var result = _movieTheaterService.GetMovieTheaterById(id);

            return result.IsSuccess ? Ok(result.Value) : GetErrorResult(result);
        }

        [HttpGet]
        public IActionResult GetMovieTheaterList()
        {
            var result = _movieTheaterService.GetMovieTheaterList();

            return result.IsSuccess ? Ok(result.Value) : GetErrorResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieById(int id, [FromBody] UpdateMovieTheaterDto updateMovieTheaterDto)
        {
            var result = _movieTheaterService.UpdateMovieById(id, updateMovieTheaterDto);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieById(int id)
        {
            var result = _movieTheaterService.DeleteMovieById(id);

            return result.IsSuccess ? Ok() : GetErrorResult(result);;
        }
    }
}
