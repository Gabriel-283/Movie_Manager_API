using System;

namespace Movie.Domain.Model.Exceptions
{
    public class MovieAPIException : Exception
    {
        public MovieAPIException(string message) : base(message) { }
    }
}
