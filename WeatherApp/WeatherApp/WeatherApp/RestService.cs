using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal static class RestService
    {
        public static async Task<T> GetData<T>(string url) where T : class
        {
            T res = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<T>(content);
                }
                return res;
            }
        }
    }
}
