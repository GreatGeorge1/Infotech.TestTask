
using System.Text.Json.Serialization;

namespace Infotech.TestTask.Webapi.Dto
{
    public class GetCarsByPersonIdRequest
    {
        [JsonPropertyName("person_id")]
        public long PersonId {get;set;}
    }
}