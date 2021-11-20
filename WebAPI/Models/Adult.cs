using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models {
    
    [Table("Adults")]
public class Adult : Person {
    [JsonPropertyName("JobTitle")]
    [ForeignKey("Job")]
    public Job JobTitle { get; set; }

    public Adult()
    {
        JobTitle = new Job();
    }
}
}