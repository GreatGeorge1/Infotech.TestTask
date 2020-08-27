using System;
using System.Collections.Generic;

namespace Infotech.TestTask.Webapi.Models
{
    public class Car
    {
        public long Id {get;set;}
        /// <summary>
        /// Державний номер автомобіля
        /// </summary>
        /// <value></value>
        public string NationalId {get;set;}
        public string VIN { get; set; }
        public string Maker {get;set;}
        public string Model { get; set; }
        public string Color{get;set;}
        public DateTime YearOfManufacture {get;set;}

        public IList<PersonCar> PersonCars {get;set;}
    }
}