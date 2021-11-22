using System.Text.Json.Serialization;

namespace WebClient.Models {
    public class Interest {
        [JsonPropertyName("Type")]
        public string Type { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
    }
}