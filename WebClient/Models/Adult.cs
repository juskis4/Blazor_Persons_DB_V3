using System.Text.Json.Serialization;

namespace WebClient.Models {
public class Adult : Person {
    [JsonPropertyName("JobTitle")]
    public Job JobTitle { get; set; }

    public Adult()
    {
        JobTitle = new Job();
    }
}
}