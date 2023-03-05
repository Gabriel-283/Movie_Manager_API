using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace Movie.Infra.EfCore
{
    public class AppDbContext : DbContext
    {
        public readonly int SuccededResultNumber = 1;
        public readonly string DefaultErrorSaveMessage = "Error ocurred while save";
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheater { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Session> Session { get; set; }
        public DbSet<MovieTheaterManager> MovieTheaterManager { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().
                HasOne(address => address.MovieTheater)
                .WithOne(movieTeater => movieTeater.Address)
                .HasForeignKey<MovieTheater>(movieTather => movieTather.AddressId);

            builder.Entity<MovieTheater>().
               HasOne(movieTheater => movieTheater.MovieTheaterManager)
               .WithMany(movieTheaterManager => movieTheaterManager.MovieTheaters)
               .HasForeignKey(movieTather => movieTather.MovieTheaterManagerId);

            builder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(Session => Session.MovieId);

            builder.Entity<Session>()
               .HasOne(session => session.MovieTheater)
               .WithMany(movieTheater => movieTheater.Sessions)
               .HasForeignKey(Session => Session.MovieTheaterId);
        }

    }
}
