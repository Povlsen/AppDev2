using Newtonsoft.Json;

namespace ClassLibrary
{
    public class FeelsLike
    {
        [JsonProperty("morn")]
        public double Morn { get; set; } 

        [JsonProperty("day")]
        public double Day { get; set; } 

        [JsonProperty("eve")]
        public double Eve { get; set; } 

        [JsonProperty("night")]
        public double Night { get; set; } 
    }
}