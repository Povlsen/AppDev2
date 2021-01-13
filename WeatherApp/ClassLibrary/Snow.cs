using Newtonsoft.Json;

namespace ClassLibrary
{
    public class Snow
    {
        [JsonPropertyAttribute("1h")]
        public double Amount { get; set; }
    }
}