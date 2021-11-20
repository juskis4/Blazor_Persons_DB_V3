using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [JsonPropertyName("id")]
        [Required]
        public int Id { get; set; }
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("photo")]
        public string Photo { get; set; }
        [JsonPropertyName("firstname")]
        [Required]
        public string FirstName { get; set; }
        [JsonPropertyName("lastname")]
        [Required]
        public string LastName { get; set; }
        [JsonPropertyName("securityLevel")]
        public int SecurityLevel { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
    
}