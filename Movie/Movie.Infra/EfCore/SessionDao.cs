using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentResults;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.ValidatorsInterfaces;

namespace Movie.Infra.EfCore
{
    public class SessionDao : ISessionDao
    {
        public AppDbContext Context { get; private set; }
        public ISessionValidator SessionValidator { get; private set; }

        public SessionDao(AppDbContext context, ISessionValidator sessionValidator)
        {
            Context = context;
            SessionValidator = sessionValidator;
        }

        public void Exclude(int id)
        {
            var session = FindById(id);

            Context.Remove(session);
            Context.SaveChanges();
        }

        public IEnumerable<Session> FindAll()
        {
            return Context.Session;
        }

        public Session FindById(int id)
        {
            return Context.Session.FirstOrDefault(session => session.Id.Equals(id));
        }

        public Result Include(Session sessionObject)
        {
            try
            {
                SessionValidator.ValidateRequest(sessionObject);

                Context.Session.Add(sessionObject);
                int result = Context.SaveChanges();

                return Result.OkIf(result.Equals(Context.SuccededResultNumber), Context.DefaultErrorSaveMessage);
            }
            catch (Exception exception)
            {
                return Result.Fail(exception.Message);
            }
            
        }

        public bool IsExistById(int id)
        {
            return !(FindById(id) is null);
        }

        public void Update(int id, Session newObj)
        {
            try
            {
                var session = FindById(id);

                session.Movie = newObj.Movie;
                session.MovieId = newObj.MovieId;
                session.EndSession = newObj.EndSession;
                session.MovieTheater = newObj.MovieTheater;
                session.MovieTheaterId = newObj.MovieTheaterId;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
