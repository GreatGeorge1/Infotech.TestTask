
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infotech.TestTask.Webapi.Dto
{
    public class GetCarsByPersonIdRequest
    {
        [Required]
        [Range(0, long.MaxValue,ErrorMessage = "The field person_id must be greater than {1}.")]
        [JsonPropertyName("person_id")]
        public long PersonId {get;set;}
    }
}