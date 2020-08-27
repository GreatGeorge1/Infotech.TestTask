using System;
using System.Collections.Generic;

namespace Infotech.TestTask.Webapi.Models
{
    public class Person
    {
        public long Id {get;set;}
        /// <summary>
        /// Ім'я
        /// </summary>
        /// <value></value>
        public string Name{get;set;}
        /// <summary>
        /// Прізвище
        /// </summary>
        /// <value></value>
        public string Surname {get;set;}
        /// <summary>
        /// По батькові
        /// </summary>
        /// <value></value>
        public string Patronymic {get;set;}
        /// <summary>
        /// Дата народження
        /// </summary>
        /// <value></value>
        public DateTime DateOfBirth {get;set;}
        /// <summary>
        /// Наприклад УНЗР людини, або номер id-картки
        /// </summary>
        /// <value></value>
        public string ExternalId{get;set;}

        public IList<PersonCar> PersonCars {get;set;}
    }
}