using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models {
    [Table("Families")]
    public class Family {
    
        [Key]
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Photo")]
        public string Photo  { get; set; }
        [JsonPropertyName("StreetName")]

        public string StreetName { get; set; }
        [JsonPropertyName("HouseNumber")]
        public int HouseNumber{ get; set; }
        [JsonPropertyName("Adults")]
        public ICollection<Adult> Adults { get; set; }
        [JsonPropertyName("Children")]
        public ICollection<Child> Children{ get; set; }
        [JsonPropertyName("Pets")]
        public ICollection<Pet> Pets{ get; set; }

        public Family() {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }
    }


}