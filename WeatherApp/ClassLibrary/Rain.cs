using Newtonsoft.Json;

namespace ClassLibrary
{
    public class Rain
    {
        [JsonProperty("1h")]
        public double Amount { get; set; }
    }
}