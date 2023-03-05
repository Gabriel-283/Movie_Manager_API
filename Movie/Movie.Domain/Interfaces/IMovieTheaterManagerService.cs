using System.Collections.Generic;
using AutoMapper;
using FluentResults;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.DTOs.MovieTheater;
using MovieAPI.Data.DTOs.MovieTheaterManager;
using MovieAPI.Models;

namespace Movie.Domain.Interfaces
{
    public interface IMovieTheaterManagerService 
    {
        public Result DeleteMovieTheaterManagerById(int id);

        public Result<MovieTheaterManager> GetMovieTheaterManagerById(int id);

        public Result<IEnumerable<MovieTheaterManager>> GetMovieTheaterManagerList();

        public Result AddMovieTheaterManager(AddMovieTheaterManagerDto movieTheaterDto);

        public Result UpdateMovieTheaterManagerById(int id, AddMovieTheaterManagerDto updateMovieTheaterDto);
    }
}