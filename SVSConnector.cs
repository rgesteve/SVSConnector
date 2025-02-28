using System.Text;
using System.Net.Http;
//using System.Text.Json; // doesn't support serialization of multi-dimensional arrays
using System.Net.Http.Headers;

using Newtonsoft.Json;

using Microsoft.Extensions.Logging;

namespace SVSConnector;

public class SVSConnector
{
   Uri _uri;
   HttpClient _client;

   public SVSConnector()
   {
     _client = new HttpClient();
     _uri = new Uri("http://localhost:5000/control/array");
   }

   public SVSConnector(string endpoint, ILoggerFactory? loggerFactory = null)
   {
   }

   public async Task SendMessageAsync(int[,] data)
   {
     //var jsonData = JsonSerializer.Serialize(data);
     var jsonData = JsonConvert.SerializeObject(data);

     _client.BaseAddress = _uri;
     _client.DefaultRequestHeaders.Accept.Clear();
     _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
     StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
     HttpResponseMessage response = await _client.PostAsync("", content);

     if (response.IsSuccessStatusCode) {
     	string responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"got the response: {responseString}");
     } else {
       Console.WriteLine($"Some problem: {response.StatusCode}");
     }
   }
}