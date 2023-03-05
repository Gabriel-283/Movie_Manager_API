using System.Collections.Generic;
using FluentResults;
using Movie.Domain.Model.DTOs.Address;
using MovieAPI.Data.DTOs.Session;
using MovieAPI.Models;

namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface ISessionService
    {
        Result AddSession(AddSessionDto updateSessionDto);
        
        Result<Session> GetSessionById(int id);
        
        Result<IEnumerable<Session>> GetSessionList();
        
        Result UpdateSessionById(int id, UpdateSessionDto updateSessionDto);
        
        Result DeleteSessionsById(int id);
    }
}