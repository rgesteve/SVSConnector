using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Headers;

namespace SVSConnector;

class Program
{
    static async Task Main(string[] args)
    {
	//var client = new HttpClient();

	/*
	var uri = new Uri("http://localhost:5000/control/ping");
	HttpResponseMessage response =
          await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));

	string content = new StreamReader(response.Content.ReadAsStream()).ReadToEnd();
        Console.WriteLine($"Received the response {content}");
	*/


	int[] data = { 11, 42, 25, 3, 4 };
	/*
	var jsonData = JsonSerializer.Serialize(data);
        Console.WriteLine($"The serialized data is: {jsonData}");

	var uri = new Uri("http://localhost:5000/control/array");
	client.BaseAddress = uri;
	client.DefaultRequestHeaders.Accept.Clear();
	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
	HttpResponseMessage response = await client.PostAsync("", content);

	if (response.IsSuccessStatusCode) {
	   string responseString = await response.Content.ReadAsStringAsync();
           Console.WriteLine($"got the response: {responseString}");
	} else {
          Console.WriteLine($"Some problem: {response.StatusCode}");
	}
	*/
	var conn = new SVSConnector();
	await conn.SendMessageAsync(data);

        Console.WriteLine("Done!");
    }
}
