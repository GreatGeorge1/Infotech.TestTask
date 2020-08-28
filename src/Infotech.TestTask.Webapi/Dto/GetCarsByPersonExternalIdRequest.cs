using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infotech.TestTask.Webapi.Dto
{
    /// <summary>
    /// Запит на отримання списку автомобілів за зовнішнім Id власника
    /// </summary>
    public class GetCarsByPersonExternalIdRequest
    {
        //https://stackoverflow.com/questions/23939738/how-can-i-use-data-annotations-attribute-classes-to-fail-empty-strings-in-forms
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [JsonPropertyName("person_external_id")]
        public string PersonExternalId {get;set;}
    }
}