using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ObjectLayer
{
    public class Sys
    {
        [Key]
        public Guid SysId { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public float Message { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }
        public virtual CurrentCity CurrentCity { get; set; }
    }
}
