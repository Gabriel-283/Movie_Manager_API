using AutoFixture;
using FluentAssertions;
using Kernel.Infra.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Login.API.Data.Requests;
using Movie.Login.API.Models;
using Movie.Login.API.Services;
using Movie.Login.Domain.Interfaces;
using System.Threading.Tasks;
using static Movie.Login.Tests.Mocks.SignInManagerMock;

namespace Movie.Login.Tests.Services
{
    [TestClass]
    public class LoginServiceTest
    {
        private Fixture _fixture;

        private Mock<IUserService> _mockUserService;
        private Mock<ITokenService> _mockTokenService;
        private Mock<FakeSignInManager> _fakeSignManager;

        private Token _token;
        private string _stringToken;
        private LoginRequest _loginRequest;
        private CustomIdentityUser customIdentityUser;

        public LoginServiceTest()
        {
            _fixture = new Fixture();

            InitStubs();
            MockDependencies();
        }

        public void InitStubs()
        {
            _token = _fixture.Create<Token>();
            _stringToken = _fixture.Create<string>();
            _loginRequest = _fixture.Create<LoginRequest>();
            customIdentityUser = _fixture.Create<CustomIdentityUser>();
        }

        public void MockDependencies()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.GetUserByEmail(It.IsAny<string>()))
                .Returns(customIdentityUser);

            _mockUserService.Setup(x => x.GetUserRole(customIdentityUser)).Returns(_stringToken);

            _mockTokenService = new Mock<ITokenService>();
            _mockTokenService.Setup(x => x.CreateToken(It.IsAny<CustomIdentityUser>(), It.IsAny<string>()))
             .Returns(_token);

            _fakeSignManager = new Mock<FakeSignInManager>();
            _fakeSignManager.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(),
                                                                It.IsAny<string>(),
                                                                It.IsAny<bool>(),
                                                                It.IsAny<bool>())).
                                                                Returns(Task.FromResult(SignInResult.Success));
        }

        [TestMethod]
        public void Should_LoginUser()
        {
            //Arrange
            var SUT = new LoginService(_mockUserService.Object, _fakeSignManager.Object, _mockTokenService.Object);

            //Act
            var result = SUT.LoginUser(_loginRequest);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void Should_ReturnInvalidUser()
        {
            //Arrange
            #region Arrange

            _mockUserService.Setup(x => x.GetUserByEmail(It.IsAny<string>()));

            var SUT = new LoginService(_mockUserService.Object, _fakeSignManager.Object, _mockTokenService.Object);

            #endregion

            //Act
            var result = SUT.LoginUser(_loginRequest);

            //Asser
            result.IsSuccess.Should().BeFalse();
            result.Reasons.Should().BeEquivalentTo(ErrorResults.GetInvalidUserResult().Reasons);
        }
    }
}
