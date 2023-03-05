using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Kernel.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Login.API.Models;
using Movie.Login.API.Services;
using Movie.Login.Domain.Interfaces;
using System;
using Movie.Login.API.Data.DTOs;
using Movie.Login.API.Enums;
using static Movie.Login.Tests.Mocks.SignInManagerMock;

namespace Movie.Login.Tests.Services
{
    [TestClass]
    public class RegisterServiceTest
    {
        private Fixture _fixture;

        private Mock<IMapper> _mockMapper;
        private Mock<IEmailTokenSender> _mockEmailService;

        private RoleManager<IdentityRole<int>> _roleManager;

        private User _customUser;
        private FakeUserManager _userManager;
        private CustomIdentityUser _customIdentityUser;

        public RegisterServiceTest()
        {
            _fixture = new Fixture();

            InitStubs();
            MockDependencies();
        }

        public void InitStubs()
        {
            _customUser = _fixture.Build<User>()
                .With(x => x.Role, RolesEnums.Admin)
                .Create();

            _userManager = new FakeUserManager();
            _customIdentityUser = _fixture.Build<CustomIdentityUser>().Create();
        }

        private void MockDependencies()
        {
            _mockMapper = new Mock<IMapper>();
            _mockEmailService = new Mock<IEmailTokenSender>();

            _mockMapper.Setup(x => x.Map<User>(It.IsAny<CreaterUserDto>())).Returns(_customUser);
            _mockMapper.Setup(x => x.Map<CustomIdentityUser>(It.IsAny<User>())).Returns(_customIdentityUser);
        }

        [TestMethod]
        public void Should_RegisterUser()
        {
            //Arrange
            var SUT = new RegisterService(_mockMapper.Object, _mockEmailService.Object, _userManager);

            //Act
            var result = SUT.RegisterUser(new CreaterUserDto());

            //Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}