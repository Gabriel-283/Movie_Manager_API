using Kernel.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Interfaces;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : AbstractController
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMovie([FromBody] AddMovieDto movieDto)
        {
            var result = _movieService.AddMovie(movieDto);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpGet]
        public IActionResult GetMoviesList()
        {
            var result = _movieService.GetMoviesList();

            return result.IsSuccess ? Ok(result.Value) : GetErrorResult(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var result = _movieService.GetMovieById(id);

            return result.IsSuccess ? Ok(result) : GetErrorResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieById(int id, [FromBody] MovieModel newMovie)
        {
            var result = _movieService.UpdateMovieById(id, newMovie);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMovieById(int id)
        {
            var result = _movieService.DeleteMovieById(id);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }
    }
}