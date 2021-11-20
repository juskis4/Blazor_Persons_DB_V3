using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        [JsonPropertyName("JobId")]
        public int Id { get; set; }
        [JsonPropertyName("JobTitle")]
        [Required, MaxLength(50)]
        public string JobTitle { get; set; }
        [JsonPropertyName("Salary")]
        [Required, Range(1000, 100000, ErrorMessage = "The salary must be between 1000 to 100000")]
        public int Salary { get; set; }
    }
}