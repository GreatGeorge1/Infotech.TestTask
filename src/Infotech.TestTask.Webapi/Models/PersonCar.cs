namespace Infotech.TestTask.Webapi.Models
{
    public class PersonCar
    {
        public long PersonId {get;set;}
        public Person Person {get;set;}

        public long CarId {get;set;}
        public Car Car {get;set;}
    }
}