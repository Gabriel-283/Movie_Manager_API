using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Login.API.Models;
using Movie.Login.API.Services;
using Movie.Login.Domain.Interfaces;
using Movie.Login.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using static Movie.Login.Tests.Mocks.SignInManagerMock;

namespace Movie.Login.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private Fixture _fixture;

        private Mock<IMapper> _mockMapper;
        private Mock<IEmailTokenSender> _mockEmailService;
        private Mock<FakeUserManager> _fakeUserManager;

        private FakeSignInManager _fakeSignManager;

        private CustomIdentityUser _customIdentity;

        private List<CustomIdentityUser> identityUsers;

        public UserServiceTest()
        {
            _fixture = new Fixture();

            InitStubs();
            MockDependencies();
        }

        private void InitStubs()
        {
            _customIdentity = _fixture.Create<CustomIdentityUser>();
            _fakeSignManager = new FakeSignInManager();
            identityUsers = new List<CustomIdentityUser>()
            {
                new CustomIdentityUser()
                {
                    UserName = _customIdentity.UserName,
                    Email = _customIdentity.Email,
                    NormalizedEmail = _customIdentity.Email.ToUpper()
                }
            };
        }

        private void MockDependencies()
        {
            _mockMapper = new Mock<IMapper>();
            _fakeUserManager = new Mock<FakeUserManager>();
            _mockEmailService = new Mock<IEmailTokenSender>();
        }

        [TestMethod]
        public void Should_GetUserByEmail()
        {
            //Arrange
            _fakeUserManager.Setup(x => x.Users)
                            .Returns(new EnumerableQuery<CustomIdentityUser>(identityUsers));

            _fakeSignManager.UserManager = _fakeUserManager.Object;

            var SUT = new UserService(_fakeSignManager);

            //Act
            var result = SUT.GetUserByEmail(_customIdentity.Email);

            //Assert
            result.UserName.Should().Be(_customIdentity.UserName);
        }
    }
}