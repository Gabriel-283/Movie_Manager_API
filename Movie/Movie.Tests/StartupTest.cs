using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Domain.Interfaces;
using Movie.Domain.Interfaces.DaoInterfaces;
using Movie.Login.API;
using MovieAPI;
using MovieAPI.Data.ValidatorsInterfaces;

namespace Movie.Tests
{
    [TestClass]
    public class StartupTest
    {
        [TestMethod]
        public void Should_HasRequiredServices()
        {
            //Arrange
            var SUT =  Microsoft.AspNetCore.WebHost.CreateDefaultBuilder();

            //Act
            var result = SUT.UseStartup<Startup>().Build();

            //Assert
            result.Should().NotBeNull();
            result.Services.GetRequiredService<IMovieDao>().Should().NotBeNull();
            result.Services.GetRequiredService<ISessionDao>().Should().NotBeNull();
            result.Services.GetRequiredService<IAddressDao>().Should().NotBeNull();
            result.Services.GetRequiredService<IMovieService>().Should().NotBeNull();
            result.Services.GetRequiredService<IAddressService>().Should().NotBeNull();
            result.Services.GetRequiredService<ISessionService>().Should().NotBeNull();
            result.Services.GetRequiredService<IMovieTheaterDao>().Should().NotBeNull();
            result.Services.GetRequiredService<ISessionValidator>().Should().NotBeNull();
            result.Services.GetRequiredService<IMovieTheaterService>().Should().NotBeNull();
            result.Services.GetRequiredService<IMovieTheaterManagerDao>().Should().NotBeNull();
            result.Services.GetRequiredService<IMovieTheaterDaoValidator>().Should().NotBeNull();
            result.Services.GetRequiredService<IMovieTheaterManagerService>().Should().NotBeNull();
            result.Services.GetRequiredService<IMovieTheaterManagerValidator>().Should().NotBeNull();
        }
    }
}