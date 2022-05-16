using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ObjectLayer
{
    public class Wind
    {
        [Key]
        public Guid WindId { get; set; }

        [JsonProperty("speed")]
        public float Speed { get; set; }

        [JsonProperty("deg")]
        public float Degree { get; set; }
        public virtual CurrentCity CurrentCity { get; set; }
    }
}
