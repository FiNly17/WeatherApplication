using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ObjectLayer
{
    public class Coordinate
    {
        [Key]
        public Guid CoordinateId { get; set; }

        [JsonProperty("lon")]
        public double Longtitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
        public virtual CurrentCity CurrentCity { get; set; }
    }
}
