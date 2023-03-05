using AutoMapper;
using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Kernel.Infra.Extensions;
using Movie.Domain.Interfaces;
using Movie.Domain.Interfaces.DaoInterfaces;
using Movie.Domain.Model.Exceptions;
using MovieAPI.Data.DTOs.MovieTheater;
using MovieAPI.Models;
using System;
using System.Collections.Generic;

namespace Movie.Infra.Services
{
    public class MovieTheaterService : IMovieTheaterService
    {
        public IMapper Mapper { get; private set; }
        public IMovieTheaterDao MovieTheaterDao { get; private set; }

        public MovieTheaterService(IMapper mapper, IMovieTheaterDao movieTheaterDao)
        {
            Mapper = mapper;
            MovieTheaterDao = movieTheaterDao;
        }

        public Result AddMovieTheater(AddMovieTheaterDto movieTheaterDto)
        {
            try
            {
                MovieTheater movieTheater = Mapper.Map<MovieTheater>(movieTheaterDto);

                var result = MovieTheaterDao.Include(movieTheater);

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

                if (!MovieTheaterDao.IsExistById(id))
                {
                    return ErrorResults.GetNotFoundError("Cinema não encontrado");
                }

                MovieTheaterDao.Exclude(id);

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

        public Result<MovieTheater> GetMovieTheaterById(int id)
        {
            try
            {
                if (!MovieTheaterDao.IsExistById(id))
                {
                    return ErrorResults.GetNotFoundError("Cinema não encontrado");
                }

                return Result.Ok(MovieTheaterDao.FindById(id));
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

        public Result<IEnumerable<MovieTheater>> GetMovieTheaterList()
        {
            try
            {
                return MovieTheaterDao.FindAll().ToResult();
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

        public Result UpdateMovieById(int id, UpdateMovieTheaterDto updateMovieTheaterDto)
        {
            try
            {
                MovieTheater newMovieTheater = Mapper.Map<MovieTheater>(updateMovieTheaterDto);

                if (!MovieTheaterDao.IsExistById(id)) return ErrorResults.GetNotFoundError();

                MovieTheaterDao.Update(id, newMovieTheater);

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
