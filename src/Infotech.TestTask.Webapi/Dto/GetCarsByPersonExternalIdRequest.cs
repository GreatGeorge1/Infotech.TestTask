using System.Text.Json.Serialization;

namespace Infotech.TestTask.Webapi.Dto
{
    public class GetCarsByPersonExternalIdRequest
    {
        [JsonPropertyName("person_external_id")]
        public string PersonExternalId {get;set;}
    }
}