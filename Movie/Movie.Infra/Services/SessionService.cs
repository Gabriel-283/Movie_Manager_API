using AutoMapper;
using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Kernel.Infra.Extensions;
using Movie.Domain.Interfaces.DaoInterfaces;
using Movie.Domain.Model.Exceptions;
using MovieAPI.Data.DTOs.Session;
using MovieAPI.Models;
using System;
using System.Collections.Generic;

namespace Movie.Infra.Services
{
    public class SessionService : ISessionService
    {
        public IMapper Mapper { get; private set; }
        public ISessionDao SessionDao { get; private set; }

        public SessionService(IMapper mapper, ISessionDao sessionDao)
        {
            Mapper = mapper;
            SessionDao = sessionDao;
        }

        public Result AddSession(AddSessionDto addSessionDto)
        {
            try
            {
                Session movieTheater = Mapper.Map<Session>(addSessionDto);

                return SessionDao.Include(movieTheater).ToResult();
                ;
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

        public Result<Session> GetSessionById(int id)
        {
            try
            {
                if (SessionDao.IsExistById(id))
                    return ErrorResults.GetNotFoundError();

                return SessionDao.FindById(id).ToResult();
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

        public Result<IEnumerable<Session>> GetSessionList()
        {
            try
            {
                return SessionDao.FindAll().ToResult();
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

        public Result UpdateSessionById(int id, UpdateSessionDto updateSessionDto)
        {
            try
            {
                if (SessionDao.IsExistById(id))
                    return ErrorResults.GetNotFoundError();

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

        public Result DeleteSessionsById(int id)
        {
            try
            {
                if (SessionDao.IsExistById(id))
                    return ErrorResults.GetNotFoundError();
                SessionDao.Exclude(id);

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