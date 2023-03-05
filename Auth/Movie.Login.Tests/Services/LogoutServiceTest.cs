using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Login.API.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Movie.Login.Tests.Mocks.SignInManagerMock;

namespace Movie.Login.Tests.Services
{
    [TestClass]
    public class LogoutServiceTest
    {
        private Mock<FakeSignInManager> _fakeSignManager;

        public LogoutServiceTest()
        {
            MockDependencies();
        }

        public void MockDependencies()
        {
            _fakeSignManager = new Mock<FakeSignInManager>();
            _fakeSignManager.Setup(x => x.SignOutAsync()).Returns(Task.FromResult(SignInResult.Success));
        }

        [TestMethod]
        public void Should_LogoutUser()
        {
            //Arrange

            var SUT = new LogoutService(_fakeSignManager.Object);

            //Act
            var result = SUT.LogoutUser();

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void Should_ReturnErrorException()
        {
            //Arrange
            string errorMessage = "Error test";
            _fakeSignManager.Setup(x => x.SignOutAsync()).Throws(new Exception(errorMessage));
            var SUT = new LogoutService(_fakeSignManager.Object);

            //Act
            var result = SUT.LogoutUser();

            //Assert
            result.IsSuccess.Should().BeFalse();
            result.Reasons.FirstOrDefault().Message.Should().Contain(errorMessage);
        }
    }
}
