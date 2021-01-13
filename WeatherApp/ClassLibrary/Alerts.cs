using Newtonsoft.Json;

namespace ClassLibrary
{
    public class Alerts
    {
        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("start")]
        public int Sart { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}