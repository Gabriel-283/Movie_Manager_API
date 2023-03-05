using AutoFixture;
using FluentAssertions;
using FluentResults;
using Kernel.Test.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Domain.Interfaces;
using Movie.Domain.Model.DTOs.Address;
using MovieAPI.Controllers;
using MovieAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Movie.Tests.Controllers
{
    [TestClass]
    public class AdressControllerTest
    {
        private Fixture _fixture;

        private Mock<IAddressService> _mockAddressService;

        private Address _address;
        private IEnumerable<Address> _addressList;
        private AddAddressDto _addAddressDto;
        
        public AdressControllerTest()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            InitStubs();
            MockDependencies();
        }

        public void InitStubs()
        {
            _addAddressDto = new();
            _address = _fixture.Build<Address>().Create();
            _addressList = _fixture.Build<Address>().CreateMany().AsEnumerable();
        }

        public void MockDependencies()
        {
            _mockAddressService = new Mock<IAddressService>();
            _mockAddressService.Setup(x => x.AddAddress(_addAddressDto)).Returns(Result.Ok());

            _mockAddressService.Setup(x => x.GetAddressById(It.IsAny<int>()))
                                                                    .Returns(Result.Ok(_address));
            
            _mockAddressService.Setup(x => x.UpdateAddress(It.IsAny<int>(), It.IsAny<UpdateAddressDto>()))
                                                                    .Returns(Result.Ok(_address));
            
            _mockAddressService.Setup(x => x.DeleteAddress(It.IsAny<int>()))
                                                                    .Returns(Result.Ok(_address));
            
            _mockAddressService.Setup(x => x.ListAddress())
                                                                    .Returns(Result.Ok(_addressList));
        }

        [TestMethod]
        public void Should_AddAddress()
        {
            //Arrange
            var SUT = new AdressController(_mockAddressService.Object);

            //Act
            var response = SUT.AddAddress(_addAddressDto);
            var statusCodeResponse = response.GetResponseStatusCode();

            //Assert
            statusCodeResponse.Should().Be(HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void Should_GetAddresById()
        {
            //Arrange
            var SUT = new AdressController(_mockAddressService.Object);

            //Act
            var response = SUT.GetAddresById(_address.Id);
            var statusCodeResponse = response.GetResponseStatusCode();
            var responseContent = response.GetResponseContent<Address>();

            //Assert
            statusCodeResponse.Should().Be(HttpStatusCode.OK);
            responseContent.Should().Be(_address);
        }
        
        [TestMethod]
        public void Should_GetAddresList()
        {
            //Arrange
            var SUT = new AdressController(_mockAddressService.Object);

            //Act
            var response = SUT.GetAddresList();
            var statusCodeResponse = response.GetResponseStatusCode();
            var responseContent = response.GetResponseContent<IEnumerable<Address>>();

            //Assert
            statusCodeResponse.Should().Be(HttpStatusCode.OK);
            responseContent.Should().BeEquivalentTo(_addressList);
        }
        
        [TestMethod]
        public void Should_UpdateAddressById()
        {
            //Arrange
            var updateAddres = _fixture.Build<UpdateAddressDto>().Create();
            var SUT = new AdressController(_mockAddressService.Object);

            //Act
            var response = SUT.UpdateAddressById(_address.Id, updateAddres);
            var statusCodeResponse = response.GetResponseStatusCode();

            //Assert
            statusCodeResponse.Should().Be(HttpStatusCode.OK);
        }
        
        [TestMethod]
        public void Should_DeleteAddressById()
        {
            //Arrange
            var SUT = new AdressController(_mockAddressService.Object);

            //Act
            var response = SUT.DeleteAddressById(_address.Id);
            var statusCodeResponse = response.GetResponseStatusCode();

            //Assert
            statusCodeResponse.Should().Be(HttpStatusCode.OK);
        }
    }
}
