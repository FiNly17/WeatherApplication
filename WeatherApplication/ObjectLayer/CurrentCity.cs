using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ObjectLayer
{
    public class CurrentCity
    {
        public CurrentCity() : base()
        {
            Weather = new List<Weather>();
        }

        [Key]
        public Guid CurrentCityId { get; set; }


        [JsonProperty("id")]
        public int Id { get; set; }

        public Guid CoordinateId { get; set; }

        [JsonProperty("coord")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("weather")]
        public IList<Weather> Weather { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        public Guid MainId { get; set; }
        [JsonProperty("main")]
        public virtual MainInformation Main { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        public Guid WindId { get; set; }
        [JsonProperty("wind")]
        public virtual Wind Wind { get; set; }

        public Guid CloudsId { get; set; }
        [JsonProperty("clouds")]
        public virtual Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public string Dt { get; set; }

        public Guid SysId { get; set; }
        [JsonProperty("sys")]
        public virtual Sys Sys { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public int Code { get; set; }
    }
}
