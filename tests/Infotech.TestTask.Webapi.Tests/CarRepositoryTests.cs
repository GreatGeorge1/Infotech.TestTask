using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infotech.TestTask.Webapi.EntityFrameworkCore;
using Infotech.TestTask.Webapi.Models;
using Infotech.TestTask.Webapi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;

namespace Infotech.TestTask.Webapi.Tests
{
    public class CarRepositoryTests
    {
        [Fact]
        public async Task GetByOwner_ReturnsCarList_GivenPersonId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using(var context = new ApplicationContext(options))
            {
                DbInitializer.Initialize(context);
            }
            using(var context = new ApplicationContext(options))
            {
                var repo = new CarRepository(context);
                //Act
                var result = await repo.GetByOwner(12);
                //Assert
                var value= Assert.IsAssignableFrom<IEnumerable<Car>>(result).OrderBy(c=>c.Id);
                var car1 = value.First();
                Assert.Equal(9,car1.Id);
                var car2 = value.Skip(1).First();
                Assert.Equal(10,car2.Id);
                var car3 = value.Skip(2).First();
                Assert.Equal(11,car3.Id);
                var car4 = value.Skip(3).Single();
                Assert.Equal(12,car4.Id);
            }
        }
        
        [Fact]
        public async Task GetByOwner_ReturnsEmptyCarList_GivenPersonId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using(var context = new ApplicationContext(options))
            {
                DbInitializer.Initialize(context);
            }
            using(var context = new ApplicationContext(options))
            {
                var repo = new CarRepository(context);
                //Act
                var result = await repo.GetByOwner(16);
                //Assert
                var value= Assert.IsAssignableFrom<IEnumerable<Car>>(result);
                Assert.Empty(value);
            }
        }
        
        [Fact]
        public async Task GetByOwner_ReturnsCarList_GivenPersonExternalId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using(var context = new ApplicationContext(options))
            {
                DbInitializer.Initialize(context);
            }
            using(var context = new ApplicationContext(options))
            {
                var repo = new CarRepository(context);
                //Act
                var result = await repo.GetByOwner("228-29-1768");
                //Assert
                var value= Assert.IsAssignableFrom<IEnumerable<Car>>(result).OrderBy(c=>c.Id);
                var car1 = value.First();
                Assert.Equal(9,car1.Id);
                var car2 = value.Skip(1).First();
                Assert.Equal(10,car2.Id);
                var car3 = value.Skip(2).First();
                Assert.Equal(11,car3.Id);
                var car4 = value.Skip(3).Single();
                Assert.Equal(12,car4.Id);
            }
        }
        
        [Fact]
        public async Task GetByOwner_ReturnsEmptyCarList_GivenPersonExternalId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using(var context = new ApplicationContext(options))
            {
                DbInitializer.Initialize(context);
            }
            using(var context = new ApplicationContext(options))
            {
                var repo = new CarRepository(context);
                //Act
                var result = await repo.GetByOwner("someFake");
                //Assert
                var value= Assert.IsAssignableFrom<IEnumerable<Car>>(result).OrderBy(c=>c.Id);
                Assert.Empty(result);
            }
        }

        [Fact]
        public async Task GetOwners_ReturnsCarList_GivenCarId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using(var context = new ApplicationContext(options))
            {
                DbInitializer.Initialize(context);
            }
            using(var context = new ApplicationContext(options))
            {
                var repo = new CarRepository(context);
                //Act
                var result = await repo.GetOwners(1);
                //Assert
                var value= Assert.IsAssignableFrom<IEnumerable<Person>>(result).OrderBy(p=>p.Id);
                var person1 = value.First();
                Assert.Equal(1,person1.Id);
                var person2 = value.Skip(1).First();
                Assert.Equal(2,person2.Id);
                var person3 = value.Skip(2).Single();
                Assert.Equal(3,person3.Id);
            }
        }
        
        [Fact]
        public async Task GetOwners_ReturnsEmptyCarList_GivenCarId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using(var context = new ApplicationContext(options))
            {
                DbInitializer.Initialize(context);
            }
            using(var context = new ApplicationContext(options))
            {
                var repo = new CarRepository(context);
                //Act
                var result = await repo.GetOwners(15);
                //Assert
                var value= Assert.IsAssignableFrom<IEnumerable<Person>>(result).OrderBy(p=>p.Id);
                Assert.Empty(result);
            }
        }
        
        [Fact]
        public async Task GetOwners_ReturnsCarList_GivenCarNationalId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using(var context = new ApplicationContext(options))
            {
                DbInitializer.Initialize(context);
            }
            using(var context = new ApplicationContext(options))
            {
                var repo = new CarRepository(context);
                //Act
                var result = await repo.GetOwners("BM7105AX");
                //Assert
                var value= Assert.IsAssignableFrom<IEnumerable<Person>>(result).OrderBy(p=>p.Id);
                var person1 = value.First();
                Assert.Equal(1,person1.Id);
                var person2 = value.Skip(1).First();
                Assert.Equal(2,person2.Id);
                var person3 = value.Skip(2).Single();
                Assert.Equal(3,person3.Id);
            }
        }
        
        [Fact]
        public async Task GetOwners_ReturnsEmptyCarList_GivenCarNationalId()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using(var context = new ApplicationContext(options))
            {
                DbInitializer.Initialize(context);
            }
            using(var context = new ApplicationContext(options))
            {
                var repo = new CarRepository(context);
                //Act
                var result = await repo.GetOwners("someFake");
                //Assert
                var value= Assert.IsAssignableFrom<IEnumerable<Person>>(result).OrderBy(p=>p.Id);
                Assert.Empty(value);
            }
        }
    }
}