using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ObjectLayer
{
    public class Weather
    {
        [Key]
        public Guid WeatherId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        public Guid CurrentCityId { get; set; }
        public virtual CurrentCity CurrentCity { get; set; }
    }
}
