using System;
using System.Text.Json.Serialization;

namespace Infotech.TestTask.Webapi.Dto
{
    public class PersonDto
    {
        [JsonPropertyName("id")]
        public long Id {get;set;}
        [JsonPropertyName("name")]
        public string Name {get;set;}
        [JsonPropertyName("surname")]
        public string Surname {get;set;}
        [JsonPropertyName("patronymic")]
        public string Patronymic {get;set;}
        [JsonPropertyName("date_of_birth")]
        public DateTime DateOfBirth {get;set;}
        [JsonPropertyName("external_id")]
        public string ExternalId{get;set;}
    }
}