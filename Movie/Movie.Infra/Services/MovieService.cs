using AutoMapper;
using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Kernel.Infra.Extensions;
using Movie.Domain.Interfaces;
using Movie.Domain.Interfaces.DaoInterfaces;
using Movie.Domain.Model.Exceptions;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Models;
using System;
using System.Collections.Generic;

namespace Movie.Infra.Services
{
    public class MovieService : IMovieService
    {
        public IMapper Mapper { get; private set; }
        public IMovieDao MovieDao { get; private set; }

        public MovieService(IMapper mapper, IMovieDao movieDao)
        {
            MovieDao = movieDao;
            Mapper = mapper;
        }

        public Result AddMovie(AddMovieDto movieDto)
        {
            try
            {
                MovieModel movie = Mapper.Map<MovieModel>(movieDto);

                var result = MovieDao.Include(Mapper.Map<MovieModel>(movie));

                return result;
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result DeleteMovieById(int id)
        {
            try
            {
                if (!MovieDao.IsExistById(id)) return ErrorResults.GetNotFoundError("Filme não encontrao");

                MovieDao.Exclude(id);

                return Result.Ok();
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result<MovieModel> GetMovieById(int id)
        {
            try
            {
                return MovieDao.IsExistById(id)? Result.Ok(MovieDao.FindById(id)) : ErrorResults.GetNotFoundError("Filme não encontrao");
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result<IEnumerable<MovieModel>> GetMoviesList()
        {
            try
            {
                var result = MovieDao.FindAll();

                return result.ToResult();
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result UpdateMovieById(int id, MovieModel newMovie)
        {
            try
            {
                if (!MovieDao.IsExistById(id)) return ErrorResults.GetNotFoundError("Filme não encontrao");

                MovieDao.Update(id, newMovie);

                return Result.Ok();
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }
    }
}
