using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Infotech.TestTask.Webapi.Controllers;
using Infotech.TestTask.Webapi.Dto;
using Infotech.TestTask.Webapi.Models;
using Infotech.TestTask.Webapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Infotech.TestTask.Webapi.Tests
{
    public class CarControllerTests
    {
        #region GetOwnersByIdTests
        [Fact]
        public async Task GetOwnersById_ReturnsPersonDtoList_GivenId()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var personProfile=new PersonProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(personProfile));
            IMapper mapper=new Mapper(conf);
            mockRepo.Setup(repo => repo.GetOwners(1)).ReturnsAsync(GetTestOwners());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetOwnersById(id:1);
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PersonDto>>>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<PersonDto>>(actionResult.Value);
            var person = returnValue.Single();
            Assert.Equal("TestPerson", person.Name);
        }
        
        [Fact]
        public async Task GetOwnersById_ReturnsBadRequestObjectResult_GivenNegative()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var personProfile=new PersonProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(personProfile));
            IMapper mapper=new Mapper(conf);
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetOwnersById(-1);
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PersonDto>>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }
        
        [Fact]
        public async Task GetOwnersById_ReturnsNotFoundObject_GivenId()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var personProfile=new PersonProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(personProfile));
            IMapper mapper=new Mapper(conf);
            mockRepo.Setup(repo => repo.GetOwners(1)).ReturnsAsync(new List<Person>());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetOwnersById(1);
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PersonDto>>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
        #endregion
        
        #region GetOwnersByNationalIdTests
        [Fact]
        public async Task GetOwnersByNationalId_ReturnsPersonDtoList_GivenId()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var personProfile=new PersonProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(personProfile));
            IMapper mapper=new Mapper(conf);
            var _nationalId = "AE4598HA";
            mockRepo.Setup(repo => repo.GetOwners(_nationalId)).ReturnsAsync(GetTestOwners());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetOwnersByNationalId(id:_nationalId);
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PersonDto>>>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<PersonDto>>(actionResult.Value);
            var person = returnValue.Single();
            Assert.Equal("TestPerson",person.Name);
        }

        [Fact]
        public async Task GetOwnersByNationalId_ReturnsNotFoundObject_GivenId()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var personProfile=new PersonProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(personProfile));
            IMapper mapper=new Mapper(conf);
            mockRepo.Setup(repo => repo.GetOwners("AE4598HA")).ReturnsAsync(new List<Person>());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetOwnersByNationalId("AE4598HA");
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PersonDto>>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetOwnersByNationalId_ReturnsBadRequestResult_GivenEmptyOrWhitespace()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var personProfile=new PersonProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(personProfile));
            IMapper mapper=new Mapper(conf);
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result1 = await controller.GetOwnersByNationalId("");
            var result2 = await controller.GetOwnersByNationalId(" ");
            //Assert
            var actionResult1 = Assert.IsType<ActionResult<IEnumerable<PersonDto>>>(result1);
            var actionResult2 = Assert.IsType<ActionResult<IEnumerable<PersonDto>>>(result2);
            Assert.IsType<BadRequestResult>(actionResult1.Result);
            Assert.IsType<BadRequestResult>(actionResult2.Result);
        }
        #endregion
        
        #region GetCarsByPersonIdTests
        [Fact]
        public async Task GetCarsByPersonId_ReturnsNotFoundResult_GivenPersonId()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var personProfile=new PersonProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(personProfile));
            IMapper mapper=new Mapper(conf);
            mockRepo.Setup(repo => repo.GetByOwner(1)).ReturnsAsync(new List<Car>());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetCarsByPersonId(new GetCarsByPersonIdRequest{PersonId = 1});
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CarDto>>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetCarsByPersonId_ReturnsBadRequestObjectResult_InvalidModel()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var carProfile=new CarProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(carProfile));
            IMapper mapper=new Mapper(conf);
            var controller=new CarController(mockRepo.Object,mapper);
            controller.ModelState.AddModelError("fakeError","fakeError");
            //Act 
            var result = await controller.GetCarsByPersonId(new GetCarsByPersonIdRequest());
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CarDto>>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetCarsByPersonId_ReturnsCarDtoList_GivenId()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var carProfile=new CarProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(carProfile));
            IMapper mapper=new Mapper(conf);
            mockRepo.Setup(repo => repo.GetByOwner(1)).ReturnsAsync(GetTestCars());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetCarsByPersonId(new GetCarsByPersonIdRequest{PersonId = 1});
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CarDto>>>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<CarDto>>(actionResult.Value);
            var car = returnValue.Single();
            Assert.Equal("Tesla",car.Maker);
        }
        #endregion
        
        #region GetCarsByPersonExternalIdTests
        [Fact]
        public async Task GetCarsByPersonExternalId_ReturnsNotFoundResult_GivenId()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var carProfile=new CarProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(carProfile));
            IMapper mapper=new Mapper(conf);
            var externalId = "640-40-9737";
            mockRepo.Setup(repo => repo.GetByOwner(externalId)).ReturnsAsync(new List<Car>());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetCarsByPersonExternalId(new GetCarsByPersonExternalIdRequest
                {PersonExternalId = externalId});
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CarDto>>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetCarsByPersonExternalId_ReturnsBadRequestObjectResult_InvalidModel()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var carProfile=new CarProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(carProfile));
            IMapper mapper=new Mapper(conf);
            var controller=new CarController(mockRepo.Object,mapper);
            controller.ModelState.AddModelError("fakeError","fakeError");
            //Act
            var result = await controller.GetCarsByPersonExternalId(new GetCarsByPersonExternalIdRequest());
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CarDto>>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetCarsByPersonExternalId_ReturnsCarDtoList_GivenId()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var carProfile=new CarProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(carProfile));
            IMapper mapper=new Mapper(conf);
            var externalId = "640-40-9737";
            mockRepo.Setup(repo => repo.GetByOwner(externalId)).ReturnsAsync(GetTestCars());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act 
            var result = await controller.GetCarsByPersonExternalId(new GetCarsByPersonExternalIdRequest{PersonExternalId = externalId});
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CarDto>>>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<CarDto>>(result.Value);
            var car = returnValue.Single();
            Assert.Equal("Tesla",car.Maker);
        }
        #endregion
        private IEnumerable<Person> GetTestOwners()
        {
            var owners=new List<Person>();
            owners.Add(new Person{ Name = "TestPerson"});
            return owners;
        }

        private IEnumerable<Car> GetTestCars()
        {
            var cars = new List<Car>();
            cars.Add(new Car{Maker = "Tesla"});
            return cars;
        }
    }
}
