using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ObjectLayer
{
    public class MainInformation
    {
        [Key]
        public Guid MainId { get; set; }

        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("feels_like")]
        public float FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public float TempMin { get; set; }

        [JsonProperty("temp_max")]
        public float TempMax { get; set; }

        [JsonProperty("pressure")]
        public float Pressure { get; set; }

        [JsonProperty("humidity")]
        public float Humidity { get; set; }
        public virtual CurrentCity CurrentCity { get; set; }
    }
}
