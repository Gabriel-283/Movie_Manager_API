using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Login.API.Data.Requests;
using Movie.Login.API.Models;
using Movie.Login.Domain.Interfaces;
using Movie.Login.Infra.Services;
using static Movie.Login.Tests.Mocks.SignInManagerMock;

namespace Movie.Login.Tests.Services
{
    [TestClass]
    public class PasswordServiceTest
    {
        private Fixture _fixture;

        private Mock<IUserService> _mockUserService;
        private Mock<ITokenService> _mockTokenService;
        private Mock<FakeSignInManager> _fakeSignManager;

        private string _resetToken;
        private Token _token;
        private CustomIdentityUser customIdentityUser;

        public PasswordServiceTest()
        {
            _fixture = new Fixture();

            InitStubs();
            MockDependencies();
        }

        public void InitStubs()
        {
            _token = _fixture.Create<Token>();
            _resetToken = _fixture.Create<string>();
            customIdentityUser = _fixture.Create<CustomIdentityUser>();
        }

        public void MockDependencies()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.GetUserByEmail(It.IsAny<string>()))
                .Returns(customIdentityUser);

            _mockTokenService = new Mock<ITokenService>();
            _mockTokenService.Setup(x => x.GenerateResetToken(It.IsAny<SignInManager<CustomIdentityUser>>()))
                .Returns(_resetToken);

            _mockTokenService.Setup(x => x.CreateToken(It.IsAny<CustomIdentityUser>(), It.IsAny<string>()))
               .Returns(_token);

            _mockUserService.Setup(x => x.GetUserRole(customIdentityUser)).Returns(_resetToken);

            _fakeSignManager = new Mock<FakeSignInManager>();
        }

        [TestMethod]
        public void Should_RequestPasswordReset()
        {
            //Arrange
            var resetPasswordRequest = _fixture.Create<ResetPasswordRequest>();
            var SUT = new PasswordService(_mockUserService.Object, _mockTokenService.Object, _fakeSignManager.Object);

            //Act
            var result = SUT.RequestPasswordReset(resetPasswordRequest);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void Should_SetNewPassword()
        {
            //Arrange
            var setNewPasswordRequest = _fixture.Create<SetNewPasswordRequest>();
            var SUT = new PasswordService(_mockUserService.Object, _mockTokenService.Object, _fakeSignManager.Object);

            //Act
            var result = SUT.SetNewPassword(setNewPasswordRequest);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
