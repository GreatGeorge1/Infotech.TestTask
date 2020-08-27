using System;
using System.Text.Json.Serialization;

namespace Infotech.TestTask.Webapi.Dto
{
    public class CarDto
    {
        [JsonPropertyName("id")]
        public long Id {get;set;}
        [JsonPropertyName("national_id")]
        public string NationalId {get;set;}
        [JsonPropertyName("vin")]
        public string VIN { get; set; }
        [JsonPropertyName("maker")]
        public string Maker {get;set;}
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("color")]
        public string Color{get;set;}
        [JsonPropertyName("year_of_manufacture")]
        public DateTime YearOfManufacture {get;set;}
    }
}