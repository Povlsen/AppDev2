using Newtonsoft.Json;
using System;

namespace ClassLibrary
{
    public class Minutely
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(UTCDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("precipitation")]
        public double Precipitation { get; set; } 
    }
}