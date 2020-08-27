using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            //Arrange
            var mockRepo = new Mock<ICarRepository>();
            var personProfile=new PersonProfile();
            var conf=new MapperConfiguration(cfg=>cfg.AddProfile(personProfile));
            IMapper mapper=new Mapper(conf);
            mockRepo.Setup(repo => repo.GetOwners(1)).ReturnsAsync(GetTestOwners());
            var controller=new CarController(mockRepo.Object,mapper);
            //Act
            var result = await controller.GetOwners(carId:1);
            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PersonDto>>>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<PersonDto>>(actionResult.Value);
            var person = returnValue.FirstOrDefault();
            Assert.Equal("TestPerson", person.Name);
        }

        private IEnumerable<Person> GetTestOwners()
        {
            var owners=new List<Person>();
            owners.Add(new Person{ Name = "TestPerson"});
            return owners;
        }
    }
}
