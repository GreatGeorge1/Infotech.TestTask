using System;
using System.Collections.Generic;
using System.Linq;
using Infotech.TestTask.Webapi.Models;

namespace Infotech.TestTask.Webapi.EntityFrameworkCore
{
    public static class DbInitializer
    {
        public static IEnumerable<Person> PersonSeed()
        {
            return  new[] 
            {
                new Person{Id=1,Name = "Franzen", Surname = "Manicom", Patronymic = "Cyril", ExternalId = "740-92-3574", DateOfBirth = new DateTime(1964,6,23)},
                new Person{Id=2,Name="Mead",Surname = "Selvey",Patronymic = "Magda", ExternalId = "636-48-2573", DateOfBirth = new DateTime(1980,5,30)},
                new Person{Id=3,Name = "Drew", Surname = "Agdahl", Patronymic = "Byrle", ExternalId = "770-95-5434", DateOfBirth = new DateTime(1990,1,1)},
                new Person{Id=4,Name="Tremain",Surname = "Colebourne",Patronymic = "Ammamaria", ExternalId = "101-66-4231", DateOfBirth = new DateTime(1982,3,10)},
                new Person{Id=5,Name = "Mirabella", Surname = "O'Gormally", Patronymic = "Lin", ExternalId = "727-37-9810", DateOfBirth = new DateTime(1980,2,19)},
                new Person{Id=6,Name="Cassey", Surname = "Vassbender", Patronymic = "Dennie", ExternalId = "640-40-9737", DateOfBirth = new DateTime(1986,11,20)},
                new Person{Id=7,Name = "Tamara", Surname = "Hallan", Patronymic = "Wilhelmine", ExternalId = "843-45-5935", DateOfBirth = new DateTime(1995,3,10)},
                new Person{Id=8,Name="Curtice", Surname = "Alecock", Patronymic = "Adan", ExternalId = "442-11-5412", DateOfBirth = new DateTime(1960,9,19)},
                new Person{Id=9,Name = "Guillaume", Surname = "Haighton", Patronymic = "Jamie", ExternalId = "348-96-0536", DateOfBirth = new DateTime(1982,6,20)},
                new Person{Id=10,Name = "Timi", Surname = "de Wilde",Patronymic = "Bill", ExternalId = "496-15-8435", DateOfBirth = new DateTime(1974,7,11)},
                new Person{Id=11,Name = "Janot", Surname = "Father", Patronymic = "Nikita", ExternalId = "703-09-5715", DateOfBirth = new DateTime(1973,8,24)},
                new Person{Id=12,Name = "El", Surname = "Grosier", Patronymic = "Eldridge", ExternalId = "228-29-1768", DateOfBirth = new DateTime(1971,8,24)},
                new Person{Id=13,Name = "Yasmin", Surname = "Fidgett", Patronymic = "Yorker", ExternalId = "605-53-5928", DateOfBirth = new DateTime(1993,2,26)},
                new Person{Id=14,Name = "Dorisa", Surname = "Girardot", Patronymic ="Jessalin", ExternalId = "839-40-0702", DateOfBirth = new DateTime(1979,3,13)},
                new Person{Id=15,Name="Fabian", Surname = "Rissom", Patronymic = "Pierette", ExternalId = "493-87-4963", DateOfBirth = new DateTime(1966,12,16)}, 
            };
        }

        public static IEnumerable<Car> CarSeed()
        {
            return new []
            {
                new Car{Id=1,NationalId = "BM7105AX",VIN="JA32X2HU4EU658619", Maker = "Subaru", Model = "Legacy", Color = "Violet", YearOfManufacture = new DateTime(1989,1,1)},
                new Car{Id=2,NationalId = "AA2105AB", VIN="SAJWA0F75F8655018", Maker = "Jeep", Model = "Grand Cherokee", Color = "Aquamarine", YearOfManufacture = new DateTime(2005,1,1)},
                new Car{Id=3,NationalId = "AO4546BA", VIN="1G6KF54921U708941", Maker = "Honda", Model = "Insight", Color = "Mauv", YearOfManufacture = new DateTime(2004,1,1)},
                new Car{Id=4,NationalId = "BB9726HA", VIN="1FAHP3EN7AW378177", Maker = "Morgan",Model = "Aero 8",Color = "Crimson",YearOfManufacture = new DateTime(2006,1,1)},
                new Car{Id=5,NationalId = "AH3246HA", VIN = "2C3CDXEJ0DH423744", Maker = "Dodge",Model = "Shadow", Color = "Green", YearOfManufacture = new DateTime(1994,1,1)},
                new Car{Id=6,NationalId="BI7846AA", VIN="4T3BA3BB4EU740949", Maker = "Land Rover", Model = "Range Rover", Color = "Maroon", YearOfManufacture = new DateTime(2002,1,1)},
                new Car{Id=7,NationalId="AE4598HA", VIN = "WVWED7AJ7CW821477", Maker = "Kia", Model = "Borrego", Color = "Purple", YearOfManufacture = new DateTime(2009,1,1)},
                new Car{Id=8,NationalId="AP7410ME",VIN = "WAUMF98P86A987825", Maker = "BMW", Model = "8 Series", Color = "Orange", YearOfManufacture = new DateTime(1993,1,1)},
                new Car{Id=9,NationalId="AP7892ME",VIN = "3D73M3CLXAG042056", Maker = "Mercedes-Benz", Model = "GL-Class", Color = "Purple", YearOfManufacture = new DateTime(2011,1,1)},
                new Car{Id=10,NationalId="BH7452EB",VIN="5FNYF3H24FB424980", Maker = "Ford", Model="Tempo",Color = "Purple", YearOfManufacture = new DateTime(1988,1,1)},
                new Car{Id=11,NationalId="BH6598EB",VIN="1FTNX2A51AE801349", Maker="Lexus", Model = "GS", Color = "Yellow", YearOfManufacture = new DateTime(2011,1,1)},
                new Car{Id=12,NationalId="HE5384KM",VIN="3D73M3CL5BG451812", Maker = "Toyota", Model = "Avalon", Color = "Mauv", YearOfManufacture = new DateTime(2001,1,1)},
                new Car{Id=13,NationalId="HE9812KM",VIN="SAJWA4FB9CL610880", Maker = "Ford", Model = "F-Series", Color = "Mauv", YearOfManufacture = new DateTime(1988,1,1)},
                new Car{Id=14,NationalId="BO3427TC",VIN="3TMJU4GN0AM255487", Maker = "Volkswagen", Model = "Cabriolet", Color = "Red", YearOfManufacture = new DateTime(1985,1,1)}
            };
        }

        public static IEnumerable<PersonCar> PersonCarSeed()
        {
            return new []
            {
                new PersonCar{CarId = 1, PersonId = 1},
                new PersonCar{CarId = 1, PersonId = 2},
                new PersonCar{CarId = 1, PersonId = 3},
                new PersonCar{CarId = 2, PersonId = 2},
                new PersonCar{CarId = 3, PersonId = 3},
                new PersonCar{CarId = 4, PersonId = 4},
                new PersonCar{CarId = 4, PersonId = 5},
                new PersonCar{CarId = 5, PersonId = 6},
                new PersonCar{CarId = 6, PersonId = 6},
                new PersonCar{CarId = 7, PersonId = 8},
                new PersonCar{CarId = 8, PersonId = 9},
                new PersonCar{CarId = 8, PersonId = 10},
                new PersonCar{CarId = 9, PersonId = 12},
                new PersonCar{CarId = 10, PersonId = 12},
                new PersonCar{CarId = 11, PersonId = 12},
                new PersonCar{CarId = 12, PersonId = 12},
                new PersonCar{CarId = 13, PersonId = 13},
                new PersonCar{CarId = 13, PersonId = 14},
                new PersonCar{CarId = 14, PersonId = 15}
            };
        }
        
        public static void Initialize(ApplicationContext context){
            context.Database.EnsureCreated();
            if(context.People.Any()){
                return;
            }
            var people = PersonSeed();
            foreach(Person p in people){
                context.People.Add(p);
            }
            context.SaveChanges();
            var cars = CarSeed();
            foreach(Car c in cars){
                context.Cars.Add(c);
            }
            context.SaveChanges();
            var personCars = PersonCarSeed();
            foreach(PersonCar pc in personCars){
                context.Set<PersonCar>().Add(pc);
            }
            context.SaveChanges();
        }
    }
}