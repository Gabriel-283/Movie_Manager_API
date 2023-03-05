using AutoMapper;
using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Kernel.Infra.Extensions;
using Movie.Domain.Interfaces;
using Movie.Domain.Interfaces.DaoInterfaces;
using Movie.Domain.Model.Exceptions;
using MovieAPI.Data.DTOs.MovieTheaterManager;
using MovieAPI.Models;
using System;
using System.Collections.Generic;

namespace Movie.Infra.Services
{
    public class MovieTheaterManagerService : IMovieTheaterManagerService
    {
        public IMapper Mapper { get; private set; }
        public IMovieTheaterManagerDao MovieTheaterManagerDao { get; private set; }

        public MovieTheaterManagerService(IMovieTheaterManagerDao movieTheaterManagerDao, IMapper mapper)
        {
            MovieTheaterManagerDao = movieTheaterManagerDao;
            Mapper = mapper;
        }

        public Result DeleteMovieTheaterManagerById(int id)
        {
            try
            {
                if (!MovieTheaterManagerDao.IsExistById(id))
                    return ErrorResults.GetNotFoundError();

                MovieTheaterManagerDao.Exclude(id);
                
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

        public Result<MovieTheaterManager> GetMovieTheaterManagerById(int id)
        {
            try
            {
                if (!MovieTheaterManagerDao.IsExistById(id))
                    return ErrorResults.GetNotFoundError();

                return MovieTheaterManagerDao.FindById(id).ToResult();
            
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

        public Result<IEnumerable<MovieTheaterManager>> GetMovieTheaterManagerList()
        {
            try
            {
                return MovieTheaterManagerDao.FindAll().ToResult();
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

        public Result AddMovieTheaterManager(AddMovieTheaterManagerDto addMovieTheaterDto)
        {
            try
            {
                MovieTheaterManager movieTheaterManager = Mapper.Map<MovieTheaterManager>(addMovieTheaterDto);
                
                return MovieTheaterManagerDao.Include(movieTheaterManager);
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

        public Result UpdateMovieTheaterManagerById(int id, AddMovieTheaterManagerDto updateMovieTheaterDto)
        {
            try
            {
                MovieTheaterManager newMovieTheater = Mapper.Map<MovieTheaterManager>(updateMovieTheaterDto);

                if (!MovieTheaterManagerDao.IsExistById(id))
                    return ErrorResults.GetNotFoundError();
                
                MovieTheaterManagerDao.Update(id, newMovieTheater);

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