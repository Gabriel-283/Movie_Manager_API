namespace Movie.Domain.Interfaces
{
    public interface IService <T>
    {
        public Result AddMovie(AddMovieDto movieDto);

        public Result<IEnumerable<MovieModel>> GetMoviesList();

        public Result<MovieModel> GetMovieById(int id);

        public Result UpdateMovieById(int id, MovieModel newMovie);

        public Result DeleteMovieById(int id);
    }
}