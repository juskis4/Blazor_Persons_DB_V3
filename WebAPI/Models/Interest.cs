using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models {
    [Table("Interests")]
public class Interest {
    [Key, Required]
    public int Id { get; set; }
    [JsonPropertyName("Type")]
    public string Type { get; set; }
    [JsonPropertyName("Description")]
    [Required, MaxLength(100, ErrorMessage = "Description too long(MAX 100 characters)")]
    public string Description { get; set; }
}
}