using System.Text.Json.Serialization;

namespace WebClient.Models {
    public class Pet {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Species")]
        public string Species { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Age")]
        public int Age { get; set; }
    }
}