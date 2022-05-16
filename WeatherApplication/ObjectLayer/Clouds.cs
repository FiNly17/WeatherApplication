using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ObjectLayer
{
    public class Clouds
    {
        [Key]
        public Guid CloudsId { get; set; }

        [JsonProperty("all")]
        public int All { get; set; }

        public virtual CurrentCity CurrentCity { get; set; }
    }
}